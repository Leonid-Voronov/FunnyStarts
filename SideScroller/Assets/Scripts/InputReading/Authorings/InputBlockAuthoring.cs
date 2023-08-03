using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class InputBlockAuthoring : MonoBehaviour
    {
    }

    public class InputBlockBaker : Baker<InputBlockAuthoring>
    {
        public override void Bake(InputBlockAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            InputBlock component = new InputBlock();
            AddComponent(entity, component);
        }
    }
}
