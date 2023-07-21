using Unity.Entities;
using Unity.Mathematics;

namespace TIC.FunnyStarts
{
    /*Summary
     * Component stores normal of surface, on which entity is standing
     */
    public struct SurfaceNormal : IComponentData
    {
        public float3 value;
    }
}

