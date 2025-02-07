using _1bit.Scripts.SettingsScript;

namespace _1bit.Scripts.Player
{
    public class PlayerHealth
    {
        private PlayerConfig _playerConfig;
        
        public float Health { get; private set; }
        public bool IsDead => Health <= 0;
        

        public PlayerHealth(PlayerConfig playerConfig)
        {
            _playerConfig = playerConfig;
            Health = _playerConfig.MaxHealth;
        }

        public void TakeDamage(float damage)
        {
            if(!IsDead)
                Health -= damage;
        }
    }
}