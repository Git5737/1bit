using _1bit.Scripts.Core;
using _1bit.Scripts.Player;
using _1bit.Scripts.SettingsScript;
using UnityEngine;

namespace _1bit.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour, IInitializable
    {
        [SerializeField] private EnemyConfig _enemyConfig;
        
        [SerializeField] private Transform _pointA;
        [SerializeField] private Transform _pointB;
        [SerializeField] private PlayerController _player;
        
        private EnemyMovement _enemyMovement;
        private EnemyAtack _enemyAtack;
        
        public void Initialize()
        {
            _enemyMovement = new EnemyMovement(_pointA, _pointB, transform, _enemyConfig);
            _enemyAtack = new EnemyAtack(_enemyConfig, _player);
        }
        
        private void Update()
        {
            _enemyMovement.Move();
            
            if (Vector3.Distance(transform.position, _player.transform.position) <= _enemyConfig.AttackRange)
            {
               _enemyAtack.ApplyDamage();
            }
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _enemyConfig.AttackRange);
        }
    }
}