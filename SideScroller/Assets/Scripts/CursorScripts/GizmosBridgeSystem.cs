using Unity.Entities;
using Unity.Mathematics;

namespace TIC.FunnyStarts
{
    public partial class GizmosBridgeSystem : SystemBase
    {
        /*
         This system need to Write a point data to MonoBehavior Gizmos class for visual debugging 
        */
        protected override void OnUpdate()
        {
            WorldCursorPosition wp = SystemAPI.GetSingleton<WorldCursorPosition>();
            float3 pos3 = new float3(0,0,0);
            GizmosDrawer.gizmos.WriteData(pos3, wp._worldCursorPosition);
        }
    }
}