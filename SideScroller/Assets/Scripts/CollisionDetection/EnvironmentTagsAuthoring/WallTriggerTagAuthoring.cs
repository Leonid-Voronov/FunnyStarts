using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class WallTriggerTagAuthoring : MonoBehaviour
    {

    }

    public class WallTriggerTagBaker : Baker<WallTriggerTagAuthoring>
    {
        public override void Bake(WallTriggerTagAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            WallTriggerTag component = new WallTriggerTag();
            AddComponent(entity, component);
        }
    }
}

