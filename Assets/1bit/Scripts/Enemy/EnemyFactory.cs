using System.Collections.Generic;
using _1bit.Scripts.SettingsScript;
using UnityEngine;
using UnityEngine.Pool;

namespace _1bit.Scripts.Enemy
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EnemyConfig[] _enemyConfigs;

        private Dictionary<string, ObjectPool<Enemy>> enemyPools = new Dictionary<string, ObjectPool<Enemy>>();

        private void Awake()
        {
            foreach (var data in _enemyConfigs)
            {
                // var pool = new ObjectPool<Enemy>(
                //     createFunc: () => Instantiate(data.Prefab).GetComponent<Enemy>(),
                //     actionOnGet: (enemy) => enemy.gameObject.SetActive(true),
                //     actionOnRelease: (enemy) => enemy.gameObject.SetActive(false)
                // );
                //enemyPools.Add(data.name, pool);
            }
        }

        public Enemy CreateEnemy(string enemyType, Vector3 position)
        {
            if (enemyPools.TryGetValue(enemyType, out var pool))
            {
                var enemy  = pool.Get();
                enemy.transform.position = position;
                return enemy;
            }

            return null;
        }
    }
}