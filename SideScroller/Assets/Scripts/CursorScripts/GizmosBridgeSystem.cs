using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace TIC.FunnyStarts
{
    [UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = false)]
    public partial class GizmosBridgeSystem : SystemBase
    {
        /*
         This system need to Write a point data to MonoBehavior Gizmos class for visual debugging 
        */
        protected override void OnUpdate()
        {
            foreach (var shootRequest in SystemAPI.Query<RefRO<ShootRequest>>())
            {
                var cp = SystemAPI.GetSingleton<CursorPosition>();
                var pos3 = new float3(0, 0, 0);
                GizmosDrawer.gizmos.WriteData(pos3, cp.cursorPosition);
            }
        }
    }
}