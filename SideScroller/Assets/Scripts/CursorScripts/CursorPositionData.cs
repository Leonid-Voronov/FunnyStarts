using Unity.Entities;
using Unity.Mathematics;

namespace TIC.FunnyStarts
{
    //public class WorldCursorPositionWrapper : ComponentDataWrapper<WorldCursorPosition> {}
    [System.Serializable]
    public struct MousePosition : IComponentData
    {
        public float2 _mousePosition;
    }
    
    [System.Serializable]
    public struct WorldCursorPosition : IComponentData
    {
        public float3 _worldCursorPosition;
    }
}