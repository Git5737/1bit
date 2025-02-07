using _1bit.Scripts.Player;
using _1bit.Scripts.SettingsScript;

namespace _1bit.Scripts.Enemy
{
    public class EnemyAtack
    {
        private EnemyConfig _enemyConfig;
        private PlayerController _playerControls;
        
        public EnemyAtack(EnemyConfig enemyConfig, PlayerController playerControls)
        {
            _enemyConfig = enemyConfig;
            _playerControls = playerControls;
        }

        public void ApplyDamage()
        {
            _playerControls.TakeDemage(_enemyConfig.DemageValue);
        }
    }
}