using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TIC.FunnyStarts
{
    public partial class ScreenCursorPositionWriter : SystemBase
    {
        
        protected override void OnCreate()
        {
            EntityManager.CreateSingleton<MousePosition>();
            SystemAPI.SetSingleton<MousePosition>( new MousePosition { _mousePosition = new float2(0,0)});
        }

        protected override void OnUpdate()
        {
            WriteCursorPosition();
        }

        private void WriteCursorPosition()
        {
            foreach (var shootRequest in SystemAPI.Query<RefRO<ShootRequest>>())
            {
                MousePosition position = SystemAPI.GetSingleton<MousePosition>();
                position._mousePosition = Mouse.current.position.value;
                SystemAPI.SetSingleton<MousePosition>(position);
            }
        }
    }
}