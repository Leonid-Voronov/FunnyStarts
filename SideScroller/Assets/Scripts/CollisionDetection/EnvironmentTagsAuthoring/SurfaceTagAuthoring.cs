using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class SurfaceTagAuthoring : MonoBehaviour
    {

    }

    public class SurfaceTagBaker : Baker<SurfaceTagAuthoring>
    {
        public override void Bake(SurfaceTagAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            SurfaceTag component = new SurfaceTag();
            AddComponent(entity, component);        
        }
    }
}

