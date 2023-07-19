using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace TIC.FunnyStarts
{
    //public class WorldCursorPositionWrapper : ComponentDataWrapper<WorldCursorPosition> {}
    [System.Serializable]
    public struct MousePositionData : IComponentData
    {
        public float2 mousePosition;
    }
    
    [System.Serializable]
    public struct WorldCursorPosition : IComponentData
    {
        public float3 _worldCursorPosition;
    }
}