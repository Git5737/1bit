using _1bit.Scripts.Core.InputSystem;
using _1bit.Scripts.SettingsScript;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _1bit.Scripts.Player
{
    public class PlayerMovement
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly InputHandler _inputHandler;
        private readonly PlayerConfig _config;
        private float _smoothing;
        private float _accelerationTime = 0.1f;

        public PlayerMovement(Rigidbody2D rigidbody, PlayerConfig config, InputHandler playerInput)
        {
            _rigidbody = rigidbody;
            _inputHandler = playerInput;
            _config = config;
        }

        public void HandleMovement()
        {
            var targetSpeed = _inputHandler.MoveDirectino.x * _config.MoveSpeed;
            var currrentSpeed = Mathf.SmoothDamp(_rigidbody.linearVelocity.x, targetSpeed, ref _smoothing, _accelerationTime);
            _rigidbody.linearVelocity = new Vector2(currrentSpeed, _rigidbody.linearVelocity.y);
        }
    }
}