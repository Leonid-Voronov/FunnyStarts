using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class CoverTriggerTagAuthoring : MonoBehaviour
    {

    }

    public class CoverTriggerTagBaker : Baker<CoverTriggerTagAuthoring>
    {
        public override void Bake(CoverTriggerTagAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            CoverTriggerTag component = new CoverTriggerTag();
            AddComponent(entity, component);
        }
    }
}

