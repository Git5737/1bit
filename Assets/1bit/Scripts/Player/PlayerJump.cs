using _1bit.Scripts.Core.InputSystem;
using _1bit.Scripts.SettingsScript;
using UnityEngine;

namespace _1bit.Scripts.Player
{
    public class PlayerJump
    {
        private readonly Rigidbody2D _rigidbody2D;
        private readonly InputHandler _inputHandler;
        private readonly PlayerConfig _playerConfig;
        private readonly Transform _groundCheck;

        public PlayerJump(Rigidbody2D rigidbody2D, InputHandler inputHandler, PlayerConfig playerConfig, Transform groundCheck)
        {
            _rigidbody2D = rigidbody2D;
            _inputHandler = inputHandler;
            _playerConfig = playerConfig;
            _groundCheck = groundCheck;
        }

        public void HandleJump()
        {
            if (!IsGrounded() || !_inputHandler.JumpTriggered) return;
            _rigidbody2D.linearVelocity = new  Vector2(_rigidbody2D.linearVelocity.x, _playerConfig.JumpForce);
            _inputHandler.ResetJump();
        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheck.position, _playerConfig.GroundCheckRadius, _playerConfig.GroundLayer);
        }
    }
}