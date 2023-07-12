using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TIC.FunnyStarts
{
    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
    public partial class InputBridgeSystem : SystemBase
    {
        private MovementActions _movementActions; //Have to store reference in System, cause ECS components can't have links to OOP classes

        protected override void OnCreate()
        {
            _movementActions = new MovementActions();
        }

        protected override void OnStartRunning()
        {
            _movementActions.Enable();
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
        }
    }
}

