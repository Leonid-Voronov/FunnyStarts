using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class InputJumpHoldAuthoring : MonoBehaviour
    {
    }

    public class InputJumpHoldBaker : Baker<InputJumpHoldAuthoring>
    {
        public override void Bake(InputJumpHoldAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            InputJumpHold component = new InputJumpHold();
            AddComponent(entity, component);
        }
    }
}
