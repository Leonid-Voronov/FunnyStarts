using Unity.Entities;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TIC.FunnyStarts
{
    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
    public partial class InputBridgeSystem : SystemBase
    {
        private MovementActions _movementActions; //Have to store reference in System, cause ECS components can't have links to OOP classes
        private Entity _playerEntity;

        protected override void OnCreate()
        {
            RequireForUpdate<PlayerTag>();
            RequireForUpdate<InputDirection>();

            _movementActions = new MovementActions();
        }

        protected override void OnStartRunning()
        {
            _movementActions.Enable();
            _movementActions.KeyboardMouse.Jump.performed += OnPlayerJump;
            _playerEntity = SystemAPI.GetSingletonEntity<PlayerTag>();
        }

        protected override void OnUpdate()
        {
            foreach (var inputDirection in SystemAPI.Query<RefRW<InputDirection>>())
            {
                InputAction moveDirection = _movementActions.KeyboardMouse.MoveDirection;
                inputDirection.ValueRW.value = moveDirection.ReadValue<Vector2>();
            }
        }

        protected override void OnStopRunning()
        {
            _movementActions.Disable();
            _movementActions.KeyboardMouse.Jump.performed -= OnPlayerJump;
            _playerEntity = Entity.Null;
        }

        private void OnPlayerJump (InputAction.CallbackContext callBackContext) 
        {
            if (!SystemAPI.Exists(_playerEntity)) return;

            //response to input
            Entity newEntity = EntityManager.CreateEntity();

            JumpRequest jumpRequest = new JumpRequest()
            {
                playerEntity = _playerEntity
            };
            EntityManager.AddComponent<JumpRequest>(newEntity);
        }
    }
}

