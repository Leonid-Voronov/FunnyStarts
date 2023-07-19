using Unity.Entities;
using Unity.Mathematics;

namespace TIC.FunnyStarts
{
    public struct WorldCursorPosition : IComponentData
    {
        public float3 _worldCursorPosition;
    }
}