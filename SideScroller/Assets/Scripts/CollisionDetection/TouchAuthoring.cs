using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
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
