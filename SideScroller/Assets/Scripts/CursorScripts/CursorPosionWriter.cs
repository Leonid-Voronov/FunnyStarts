using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TIC.FunnyStarts
{
    /*
     Summary
     This system transform position of Cursor on a Screen into position on camera in a game world space
     */
    [UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = false)]
    public partial class CursorPosionWriter : SystemBase
    {
        protected override void OnCreate()
        {
            EntityManager.CreateSingleton<CursorPosition>();
        }

        protected override void OnUpdate()
        {
            foreach (var shootRequest in SystemAPI.Query<RefRO<ShootRequest>>())
            {
                if(Camera.main != null){
                    CursorPosition cp = SystemAPI.GetSingleton<CursorPosition>();
                    float2 pos2 = Mouse.current.position.value;
                    float3 pos3 = Camera.main.ScreenToWorldPoint(new Vector3(pos2.x, pos2.y, Camera.main.nearClipPlane));
                    cp.cursorPosition = pos3;
                    SystemAPI.SetSingleton<CursorPosition>(cp);
                }
            }
        }
    }
}