using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class InputDirectionAuthoring : MonoBehaviour
    {
        public float2 value;
    }

    public class InputDirectionBaker : Baker <InputDirectionAuthoring> 
    {
        public override void Bake(InputDirectionAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            InputDirection component = new InputDirection()
            {
                value = authoring.value
            };

            AddComponent (entity, component);
        }
    }
}

