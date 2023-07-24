using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;


namespace TIC.FunnyStarts
{
    public class InputAimAuthoring : MonoBehaviour
    {
    }

    public class InputAimBaker : Baker<InputAimAuthoring>
    {
        public override void Bake(InputAimAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            InputAim component = new InputAim();
            AddComponent(entity, component);
        }
    }
}
