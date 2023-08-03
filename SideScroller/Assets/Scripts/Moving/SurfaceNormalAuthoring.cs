using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class SurfaceNormalAuthoring : MonoBehaviour
    {
    }

    public class SurfaceNormalBaker : Baker<SurfaceNormalAuthoring>
    {
        public override void Bake(SurfaceNormalAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            SurfaceNormal component = new SurfaceNormal();
            AddComponent(entity, component);

        }
    }
}


