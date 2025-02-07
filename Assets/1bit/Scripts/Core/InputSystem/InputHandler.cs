using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _1bit.Scripts.Core.InputSystem
{
    public class InputHandler : MonoBehaviour
    {
        private PlayerControls _playerControls;
        
        public Vector2 MoveDirectino { get; private set; }
        public bool JumpTriggered { get; private set; }

        public void Awake()
        {
            _playerControls = new PlayerControls();
            _playerControls.Enable();
        }

        private void Update()
        {
            MoveDirectino = _playerControls.Player.Move.ReadValue<Vector2>();
        }

        private void OnEnable()
        {
           // _playerControls.Player.Move.performed += ctx => MoveDirectino = ctx.ReadValue<Vector2>();
           // _playerControls.Player.Move.canceled += ctx => MoveDirectino = Vector2.zero;
           _playerControls.Player.Jump.performed += Jump;
        }

        private void Jump(InputAction.CallbackContext obj)
        {
            JumpTriggered = true;
        }

        private void OnDisable()
        {
            _playerControls.Disable();
            _playerControls.Player.Jump.performed -= Jump;
        }

        public void ResetJump()
        {
            JumpTriggered = false;
        }
    }
}