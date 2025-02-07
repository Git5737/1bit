using System;
using _1bit.Scripts.SettingsScript;
using UnityEngine;

namespace _1bit.Scripts.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected EnemyConfig _enemyConfig;
        protected float currentHealth;

        public static event Action<Enemy> OnEnemySpawned;
        public static event Action<Enemy> OnEnemyDied;

        protected virtual void Awake()
        {
            currentHealth = _enemyConfig.MaxHealth;
        }

        protected virtual void Start()
        {
            OnEnemySpawned?.Invoke(this);
        }

        public virtual void TakeDamage(float damage)
        {
           currentHealth -= damage;
           if (currentHealth <= 0)
           {
               Die();
           }
        }

        public virtual void Die()
        {
            OnEnemyDied?.Invoke(this);
            ReturnToPool();
        }

        public void ReturnToPool()
        {
            gameObject.SetActive(false);
        }
    }
}