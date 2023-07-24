using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class InputCrouchAuthoring : MonoBehaviour
    {
    }

    public class InputCrouchBaker : Baker<InputCrouchAuthoring>
    {
        public override void Bake(InputCrouchAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            InputCrouch component = new InputCrouch();
            AddComponent(entity, component);
        }
    }
}
