using Unity.Entities;
using Unity.Mathematics;
namespace TIC.FunnyStarts
{
    public struct ShootRaycast : IComponentData
    {
        public float3 target;
        public float3 start;
        //public Entity owner;
    }
}