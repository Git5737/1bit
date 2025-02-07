using UnityEngine;

namespace _1bit.Scripts.SettingsScript
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [field: Header("Movement"), SerializeField]
        [field: Tooltip("Base movement speed in units/second")]
        public float MoveSpeed { get; private set; } = 5f;

        [field: Header("Jump"), SerializeField]
        [field: Tooltip("Initial jump velocity")]
        public float JumpForce { get; private set; } = 7f;

        [field: SerializeField, Range(0.01f, 1f)]
        [field: Tooltip("Radius for ground detection")]
        public float GroundCheckRadius { get; private set; } = 0.2f;

        [field: SerializeField]
        [field: Tooltip("Layer mask for ground detection")]
        public LayerMask GroundLayer { get; private set; }
        
        [field: Header("Ladder")]
        [field: SerializeField, Range(0.01f, 1f)]
        [field: Tooltip("Radius for ladder detection")]
        public float LadderCheckRadius { get; private set; } = 0.2f;
        
        [field: SerializeField]
        [field: Tooltip("Layer mask for ladder detection")]
        public LayerMask LadderLayer { get; private set; }
        
        [field: SerializeField]
        [field: Header("Health")]
        public float MaxHealth { get; private set; } = 100f;
    }
}