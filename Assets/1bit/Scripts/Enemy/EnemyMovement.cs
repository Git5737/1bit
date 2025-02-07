using _1bit.Scripts.SettingsScript;
using UnityEngine;

namespace _1bit.Scripts.Enemy
{
    public class EnemyMovement
    {
        private Transform _pointA;
        private Transform _pointB;
        private Transform _transform;
        private EnemyConfig _enemyConfig;
        
        private Vector3 _target;
        
        public EnemyMovement(Transform pointA, Transform pointB, Transform transform, EnemyConfig enemyConfig)
        {
            _pointA = pointA;
            _pointB = pointB;
            _transform = transform;
            _enemyConfig = enemyConfig;
            
            _target = _pointB.position;
        }

        public void Move()
        {
            _transform.position = Vector3.MoveTowards(_transform.position, _target, _enemyConfig.MoveSpeed * Time.deltaTime);
        
            if (Vector3.Distance(_transform.position, _target) < 0.1f)
            {
                _target = _target == _pointA.position ? _pointB.position : _pointA.position;
            }
        }
    }
}