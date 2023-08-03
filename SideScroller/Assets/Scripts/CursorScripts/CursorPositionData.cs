using Unity.Entities;
using Unity.Mathematics;

namespace TIC.FunnyStarts
{
    //public class WorldCursorPositionWrapper : ComponentDataWrapper<WorldCursorPosition> {}
    [System.Serializable]
    public struct CursorPosition : IComponentData{
        public float3 cursorPosition;
    } 
}