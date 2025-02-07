Shader "Unlit/Rainbow"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _PulseSpeed ("Pulse Speed", Range(0, 5)) = 2     // Швидкість пульсації
        _WaveSpeed ("Wave Speed", Range(0, 10)) = 3        // Швидкість хвиль
        _Emission ("Glow Strength", Range(0, 5)) = 2       // Сила світіння
        _Distort ("Wave Distortion", Range(0, 0.2)) = 0.1  // Спотворення хвиль
        _ColorSpread ("Color Spread", Range(1, 10)) = 5    // Чіткість градієнту
    }
    SubShader
    {
        Tags 
        { 
            "Queue"="Transparent" 
            "RenderType"="TransparentCutout"
            "PreviewType"="Plane"
        }

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
            float4 _MainTex_ST;
            float _PulseSpeed;
            float _WaveSpeed;
            float _Emission;
            float _Distort;
            float _ColorSpread;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float pulse = sin(_Time.y * _PulseSpeed) * 0.5 + 0.5;
                
                float waveX = sin(i.worldPos.x * 10 + _Time.y * _WaveSpeed) * _Distort;
                float waveY = cos(i.worldPos.y * 10 + _Time.y * _WaveSpeed) * _Distort;
                float2 distortedUV = i.uv + float2(waveX, waveY);
                
                float colorPhase = i.worldPos.x * _ColorSpread + _Time.y * _WaveSpeed;
                float r = sin(colorPhase) * 0.5 + 0.5;
                float g = sin(colorPhase + 2.0) * 0.5 + 0.5;
                float b = sin(colorPhase + 4.0) * 0.5 + 0.5;
                
                float glow = pulse * _Emission;
                
                fixed4 rainbowColor = fixed4(r, g, b, 1) * glow;
                
                fixed4 tex = tex2D(_MainTex, i.uv);
                rainbowColor.a = tex.a;

                return rainbowColor;
            }
            ENDCG
        }
    }
}