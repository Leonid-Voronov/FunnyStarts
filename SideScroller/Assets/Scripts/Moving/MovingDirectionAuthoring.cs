using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;


namespace TIC.FunnyStarts
{
    public class MovingDirectionAuthoring : MonoBehaviour
    {
        public float3 value;
    }

    public class MovingDirectionBaker : Baker<MovingDirectionAuthoring>
    {
        public override void Bake(MovingDirectionAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            MovingDirection movingDirection = new MovingDirection()
            {
                value = authoring.value
            };
            AddComponent(entity, movingDirection);
        }
    }
}



