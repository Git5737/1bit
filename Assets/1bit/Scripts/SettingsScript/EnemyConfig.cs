using UnityEngine;

namespace _1bit.Scripts.SettingsScript
{
    [CreateAssetMenu(fileName = "EnemyConfigs", menuName = "Configs/EnemyConfigs")]
    public class EnemyConfig : ScriptableObject
    {
        [field: Header("Movement"), SerializeField]
        [field: Tooltip("Base movement speed in units/second")]
        public float MoveSpeed { get; private set; } = 5f;
        
        [field: Header("Health"), SerializeField]
        public float MaxHealth { get; private set; } = 100f;
        
       // public GameObject Prefab { get; private set; }

        [field: Header("Demage"), SerializeField]
        public float DemageValue { get; private set; } = 50f;

        [field: Header("Attack"), SerializeField]
        public float AttackRange { get; private set; } = 2f;
    }
}