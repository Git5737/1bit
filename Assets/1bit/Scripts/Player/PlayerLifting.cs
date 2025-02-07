using _1bit.Scripts.Core.InputSystem;
using _1bit.Scripts.SettingsScript;
using UnityEngine;

namespace _1bit.Scripts.Player
{
    public class PlayerLifting
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly InputHandler _inputHandler;
        private readonly PlayerConfig _config;
        private readonly Transform _ladderCheckPoint;
        private bool _ladderChecked;

        public PlayerLifting(Rigidbody2D rigidbody, PlayerConfig config, InputHandler playerInput, Transform ladderCheckPoint)
        {
            _rigidbody = rigidbody;
            _inputHandler = playerInput;
            _config = config;
            _ladderCheckPoint = ladderCheckPoint;
        }

        public void CheckLadder()
        {
            _ladderChecked = Physics2D.OverlapPoint(_ladderCheckPoint.position, _config.LadderLayer);
        }
        
        public void HandleLifting()
        {
            if (_ladderChecked)
            {
                _rigidbody.bodyType = RigidbodyType2D.Kinematic;
                var targetSpeed = _inputHandler.MoveDirectino.y * _config.MoveSpeed;
                _rigidbody.linearVelocity = new Vector2( _rigidbody.linearVelocity.x, targetSpeed);
            }
            else
            {
                _rigidbody.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}