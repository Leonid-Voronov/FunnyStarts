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
            EntityManager.CreateSingleton<MousePositionData>();
            SystemAPI.SetSingleton<MousePositionData>( new MousePositionData { mousePosition = new float2(0,0)});
            Debug.Log(SystemAPI.GetSingleton<WorldCursorPosition>()._worldCursorPosition);
        }

        protected override void OnUpdate()
        {
            WriteCursorPosition();
        }

        private void WriteCursorPosition()
        {
            foreach (var inputDirection in SystemAPI.Query<RefRW<ShootRequest>>())
            {
                MousePositionData position = SystemAPI.GetSingleton<MousePositionData>();
                position.mousePosition = Mouse.current.position.value;
                SystemAPI.SetSingleton<MousePositionData>(position);
                Debug.Log(SystemAPI.GetSingleton<MousePositionData>().mousePosition);
            }
        }
    }
}