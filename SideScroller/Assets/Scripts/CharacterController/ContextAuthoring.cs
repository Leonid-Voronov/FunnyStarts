using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class ContextAuthoring : MonoBehaviour
    {
    }

    public class ContextBaker : Baker<ContextAuthoring>
    {
        public override void Bake(ContextAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            Context context = new Context()
            {
                onSurface = false
            };
            AddComponent(entity, context);
        }
    }
}

