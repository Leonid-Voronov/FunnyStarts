using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class VerticalPlaneTagAuthoring : MonoBehaviour
    {

    }

    public class VerticalPlaneTagBaker : Baker<VerticalPlaneTagAuthoring>
    {
        public override void Bake(VerticalPlaneTagAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            VerticalPlaneTag component = new VerticalPlaneTag();
            AddComponent(entity, component);
        }
    }
}
