using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class NearWallTriggerTagAuthoring : MonoBehaviour
    {

    }

    public class NearWallTriggerTagBaker : Baker<NearWallTriggerTagAuthoring>
    {
        public override void Bake(NearWallTriggerTagAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            NearWallTriggerTag component = new NearWallTriggerTag();
            AddComponent(entity, component);
        }
    }
}

