using _1bit.Scripts.Player;
using UnityEngine;
using System.Collections.Generic;
using _1bit.Scripts.Enemy;


namespace _1bit.Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private LevelManager _levelManager;
        [SerializeField] private PlayerController _playerController;

        [SerializeField] private List<EnemyController> _enemyControllers = new List<EnemyController>();
       // [SerializeField] private EnemyFactory _enemyFactory;

      //  private List<Enemy.Enemy> activeEnemes = new List<Enemy.Enemy>();

        private List<IInitializable> _initializables = new();
        
        private void Awake()
        {
            SetupInitializables();
            ValidateDependencies();
            InitializeSystems();
        }

        // private void OnEnable()
        // {
        //     Enemy.Enemy.OnEnemySpawned += AddEnemy;
        //     Enemy.Enemy.OnEnemyDied += RemoveEnmey;
        // }
        //
        // private void OnDisable()
        // {
        //     Enemy.Enemy.OnEnemySpawned -= AddEnemy;
        //     Enemy.Enemy.OnEnemyDied -= RemoveEnmey;
        // }

        private void SetupInitializables()
        {
            _initializables.Add(_levelManager);
            _initializables.Add(_playerController);
            _initializables.AddRange(_enemyControllers);
        }
        
        private void ValidateDependencies()
        {
            foreach (var system in _initializables)
            {
                if(system == null)
                    Debug.LogError($"{nameof(system)} is null");
            }
        }


        private void InitializeSystems()
        {
            foreach (var system in _initializables)
            {
                system.Initialize();
            }
        }

        // private void AddEnemy(Enemy.Enemy enemy)
        // {
        //     activeEnemes.Add(enemy);
        // }
        //
        // private void RemoveEnmey(Enemy.Enemy enemy)
        // {
        //     activeEnemes.Remove(enemy);
        // }
        //
        // public void SpawnTestEnemy()
        // {
        //     _enemyFactory.CreateEnemy("NewEnemy", new Vector3(0, 5, 0));
        // }
    }
}