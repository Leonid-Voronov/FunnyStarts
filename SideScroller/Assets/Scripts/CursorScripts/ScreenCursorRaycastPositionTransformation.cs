using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace TIC.FunnyStarts
{
    /*
     Summary
     This system transform position of Cursor on a Screen into position on camera in a game world space
     */
    public partial class ScreenCursorRaycastPositionTransformation : SystemBase
    {
        protected override void OnCreate()
        {
            EntityManager.CreateSingleton<WorldCursorPosition>();
            SystemAPI.SetSingleton<WorldCursorPosition>( new WorldCursorPosition { _worldCursorPosition = new float3(0,0,0)});
        }

        protected override void OnUpdate()
        {
            foreach (var shootRequest in SystemAPI.Query<RefRO<ShootRequest>>())
            {
                if(Camera.main != null){
                    WorldCursorPosition worldCursorPosition = SystemAPI.GetSingleton<WorldCursorPosition>();
                    MousePosition screenCursorPosition = SystemAPI.GetSingleton<MousePosition>();
                    float2 pos2 = screenCursorPosition._mousePosition;
                    float3 pos3 = Camera.main.ScreenToWorldPoint(new Vector3(pos2.x, pos2.y, Camera.main.nearClipPlane));
                    worldCursorPosition._worldCursorPosition = pos3;
                    SystemAPI.SetSingleton<WorldCursorPosition>(worldCursorPosition);
                }
            }
        }
    }
}