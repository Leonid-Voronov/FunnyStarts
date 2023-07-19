using Unity.Entities;
using Unity.Mathematics;

namespace TIC.FunnyStarts
{
    public partial class GizmosBridgeSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            WorldCursorPosition wp = SystemAPI.GetSingleton<WorldCursorPosition>();
            float3 pos3 = float3.zero;
            GizmosDrawer.gizmos.WriteData(pos3, wp._worldCursorPosition);
        }
    }
}