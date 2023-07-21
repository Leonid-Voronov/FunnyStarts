using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class SurfaceNormalAuthoring : MonoBehaviour
    {
        public float3 value;
    }

    public class SurfaceNormalBaker : Baker<SurfaceNormalAuthoring>
    {
        public override void Bake(SurfaceNormalAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            SurfaceNormal component = new SurfaceNormal()
            {
                value = authoring.value
            };

            AddComponent(entity, component);

        }
    }
}


