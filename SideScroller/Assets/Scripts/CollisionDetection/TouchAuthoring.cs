using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class TouchAuthoring : MonoBehaviour
    {
    }

    public class TouchBaker : Baker<TouchAuthoring>
    {
        public override void Bake(TouchAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            Touch component = new Touch();
            AddComponent(entity, component);
        }
    }
}
