using System.Linq;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace TIC.FunnyStarts
{
    public partial class ScreenCursorRaycastPositionTransformation : SystemBase
    {
        protected override void OnCreate()
        {
            EntityManager.CreateSingleton<WorldCursorPosition>();
            SystemAPI.SetSingleton<WorldCursorPosition>( new WorldCursorPosition { _worldCursorPosition = new float3(0,0,0)});
        }

        protected override void OnUpdate()
        {
            foreach (var inputDirection in SystemAPI.Query<RefRW<ShootRequest>>())
            {
                WorldCursorPosition worldCursorPosition = SystemAPI.GetSingleton<WorldCursorPosition>();
                MousePositionData screanCursorPosition = SystemAPI.GetSingleton<MousePositionData>();
                float2 pos2 = screanCursorPosition.mousePosition;
                float3 pos3 = Camera.main.ScreenToWorldPoint(new Vector3(pos2.x, pos2.y, Camera.main.nearClipPlane));
                worldCursorPosition._worldCursorPosition = pos3;
                SystemAPI.SetSingleton<WorldCursorPosition>(worldCursorPosition);
            }
        }
    }
}