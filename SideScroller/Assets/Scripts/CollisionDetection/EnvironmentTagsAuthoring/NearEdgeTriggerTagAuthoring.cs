using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class NearEdgeTriggerTagAuthoring : MonoBehaviour
    {

    }

    public class NearEdgeTriggerTagBaker : Baker<NearEdgeTriggerTagAuthoring>
    {
        public override void Bake(NearEdgeTriggerTagAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            NearEdgeTriggerTag component = new NearEdgeTriggerTag();
            AddComponent(entity, component);
        }
    }
}

