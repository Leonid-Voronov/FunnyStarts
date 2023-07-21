using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;

/*
 * Summary
 * This system changes localTransform component of entity based on moveDirection and speed
 */
namespace TIC.FunnyStarts
{
    public partial class Mover : SystemBase
    {
        protected override void OnUpdate()
        {
            foreach (MoveAspect moveAspect in SystemAPI.Query<MoveAspect>())
            {
                float speed = moveAspect.currentMoveSpeed.ValueRO.value;
                float3 direction = moveAspect.movingDirection.ValueRO.value;

                moveAspect.physicsVelocity.ValueRW.Linear = speed * direction;
            }
        }
    }
}

