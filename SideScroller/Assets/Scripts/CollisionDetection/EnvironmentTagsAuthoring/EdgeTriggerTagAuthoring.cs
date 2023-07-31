using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class EdgeTriggerTagAuthoring : MonoBehaviour
    {

    }

    public class EdgeTriggerTagBaker : Baker<EdgeTriggerTagAuthoring>
    {
        public override void Bake(EdgeTriggerTagAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            EdgeTriggerTag component = new EdgeTriggerTag();
            AddComponent(entity, component);
        }
    }
}

