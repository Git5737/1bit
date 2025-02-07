using _1bit.Scripts.Core;
using _1bit.Scripts.Core.InputSystem;
using _1bit.Scripts.SettingsScript;
using UnityEngine;
using System;

namespace _1bit.Scripts.Player
{
    public class PlayerController : MonoBehaviour, IInitializable
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Transform _groundCheckPoint;
        [SerializeField] private Transform _ladderCheckPoint;
        
        private PlayerMovement _playerMovement;
        private PlayerJump _playerJump;
        private PlayerLifting _playerLifting;
        private PlayerHealth _playerHealth;
        private Rigidbody2D _rigidbody2D;
        private InputHandler _playerInputHandler;

        public static event Action OnHealthChanged;
        public static event Action OnDeath;

        public void Initialize()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerInputHandler = GetComponent<InputHandler>();
            
            _playerMovement = new PlayerMovement(_rigidbody2D, _playerConfig, _playerInputHandler);
            _playerJump = new PlayerJump(_rigidbody2D, _playerInputHandler, _playerConfig, _groundCheckPoint);
            _playerLifting = new PlayerLifting(_rigidbody2D, _playerConfig, _playerInputHandler, _ladderCheckPoint);
            _playerHealth = new PlayerHealth(_playerConfig);
        }

        private void FixedUpdate()
        {
            _playerMovement.HandleMovement();
            _playerJump.HandleJump();
            _playerLifting.CheckLadder();
            _playerLifting.HandleLifting();
        }

        public void TakeDemage(float demange)
        {
            _playerHealth.TakeDamage(demange);
            OnHealthChanged?.Invoke();

            if (_playerHealth.IsDead)
            {
                OnDeath?.Invoke();
                transform.position = new Vector2(0f, 0f);
            }
        }

        // Debugging tool to visualize check points
        private void OnDrawGizmos()
        {
            if (_groundCheckPoint && _ladderCheckPoint && _playerConfig)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(_groundCheckPoint.position, _playerConfig.GroundCheckRadius);
                
                Gizmos.color = Color.cyan;
                Gizmos.DrawWireSphere(_ladderCheckPoint.position, _playerConfig.LadderCheckRadius);
            }
        }
    }
}