using Unity.Entities;
using Unity.Mathematics;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TIC.FunnyStarts
{
    /*
     * Summary
     * This system connects generated C# script of input asset from InputSystem library and ECS architecture
     */

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
            _movementActions.KeyboardMouse.Shoot.performed += OnPlayerShoot;

            _playerEntity = SystemAPI.GetSingletonEntity<PlayerTag>();
        }

        protected override void OnUpdate()
        {
            foreach (var inputDirection in SystemAPI.Query<RefRW<InputDirection>>())
            {
                InputAction moveDirection = _movementActions.KeyboardMouse.MoveDirection;
                inputDirection.ValueRW.value = moveDirection.ReadValue<Vector2>();
            }

            foreach (var inputJumpHold in SystemAPI.Query<RefRW<InputJumpHold>>())
            {
                InputAction inputJumpHoldAction = _movementActions.KeyboardMouse.JumpHold;
                inputJumpHold.ValueRW.value = inputJumpHoldAction.ReadValue<float>();
            }

            foreach (var inputAim in SystemAPI.Query<RefRW<InputAim>>())
            {
                InputAction inputAimAction = _movementActions.KeyboardMouse.Aim;
                inputAim.ValueRW.value = inputAimAction.ReadValue<float>();
            }

            foreach (var inputBlock in SystemAPI.Query<RefRW<InputBlock>>())
            {
                InputAction inputBlockAction = _movementActions.KeyboardMouse.Block;
                inputBlock.ValueRW.value = inputBlockAction.ReadValue<float>();
            }

            foreach (var inputSprint in SystemAPI.Query<RefRW<InputSprint>>())
            {
                InputAction inputSprintAction = _movementActions.KeyboardMouse.Sprint;
                inputSprint.ValueRW.value = inputSprintAction.ReadValue<float>();
            }

            foreach (var inputCrouch in SystemAPI.Query<RefRW<InputCrouch>>())
            {
                InputAction inputCrouchAction = _movementActions.KeyboardMouse.Crouch;
                inputCrouch.ValueRW.value = inputCrouchAction.ReadValue<float>();
            }
        }

        protected override void OnStopRunning()
        {
            _movementActions.Disable();
            _movementActions.KeyboardMouse.Jump.performed -= OnPlayerJump;
            _movementActions.KeyboardMouse.Shoot.performed -= OnPlayerShoot;
            _playerEntity = Entity.Null;
        }

        private void OnPlayerJump (InputAction.CallbackContext callBackContext) 
        {
            if (!SystemAPI.Exists(_playerEntity)) return;

            Entity newEntity = EntityManager.CreateEntity();
            JumpRequest jumpRequest = new JumpRequest()
            {
                playerEntity = _playerEntity
            };
            EntityManager.AddComponentData<JumpRequest>(newEntity, jumpRequest);
            EntityManager.AddComponent<RequestTag>(newEntity);
        }

        private void OnPlayerShoot (InputAction.CallbackContext callbackContext)
        {
            if (!SystemAPI.Exists(_playerEntity)) return;
            Entity newEntity = EntityManager.CreateEntity();
            ShootRequest shootRequest = new ShootRequest()
            {
                playerEntity = _playerEntity
            };
            EntityManager.AddComponentData<ShootRequest>(newEntity, shootRequest);
            EntityManager.AddComponent<RequestTag>(newEntity);
        }
    } 
}

