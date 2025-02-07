Shader "Unlit/RedTint"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _Color1 ("Base Red", Color) = (1, 0.1, 0.1, 1)
        _Color2 ("Glow Red", Color) = (1, 0.5, 0.5, 1)
        _PulseSpeed ("Pulse Speed", Range(0.1, 5)) = 2
        _WaveSpeed ("Wave Speed", Range(0, 10)) = 3
        _Emission ("Glow Strength", Range(0, 5)) = 2
        _Distort ("Wave Distortion", Range(0, 0.2)) = 0.1
        _BaseBrightness ("Base Brightness", Range(0, 1)) = 0.3 // Мінімальна яскравість
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _Color1, _Color2;
            float _PulseSpeed, _WaveSpeed, _Emission, _Distort, _BaseBrightness;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Плавна пульсація без зникання
                float pulse = (sin(_Time.y * _PulseSpeed) * 0.5 + 0.5) * (1 - _BaseBrightness) + _BaseBrightness;
                
                // М'яке хвильове спотворення
                float waveX = sin(i.worldPos.x * 10 + _Time.y * _WaveSpeed) * _Distort;
                float waveY = cos(i.worldPos.y * 10 + _Time.y * _WaveSpeed) * _Distort;
                float2 distortedUV = i.uv + float2(waveX, waveY);
                
                // Градієнт для імітації світіння
                float2 center = float2(0.5, 0.5);
                float gradient = 1 - length(distortedUV - center);
                gradient = smoothstep(0.2, 0.8, gradient);
                
                // Яскравість базового кольору
                float brightness = pulse * _Emission;
                fixed4 baseColor = lerp(_Color1, _Color2, gradient);
                baseColor.rgb *= brightness;
                
                // Застосування текстури
                fixed4 tex = tex2D(_MainTex, i.uv);
                baseColor.a = tex.a; // Альфа залишається незмінною
                
                return baseColor;
            }
            ENDCG
        }
    }
}