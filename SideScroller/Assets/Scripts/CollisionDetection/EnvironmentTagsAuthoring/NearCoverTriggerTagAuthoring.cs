using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class NearCoverTriggerTagAuthoring : MonoBehaviour
    {

    }

    public class NearCoverTriggerTagBaker : Baker<NearCoverTriggerTagAuthoring>
    {
        public override void Bake(NearCoverTriggerTagAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            NearCoverTriggerTag component = new NearCoverTriggerTag();
            AddComponent(entity, component);
        }
    }
}

