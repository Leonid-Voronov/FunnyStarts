using Unity.Entities;
using Unity.Physics.Stateful;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace TIC.FunnyStarts
{
    public readonly partial struct AffectedByContextAspect : IAspect
    {
        public readonly Entity entity;

        public readonly RefRW<Context> context;
        public readonly DynamicBuffer<StatefulCollisionEvent> statefulCollisionEvents;
        public readonly DynamicBuffer<StatefulTriggerEvent> statefulTriggerEvents;
    }

    public partial class CollisionDetection : SystemBase
    {
        protected override void OnCreate()
        {
            RequireForUpdate<StatefulCollisionEvent>();
            RequireForUpdate<SurfaceTag>();
        }
        protected override void OnUpdate()
        {
            foreach (var aspect in SystemAPI.Query<AffectedByContextAspect>())
            {
                //Debug.Log("1");
                Entity affectedEntity = aspect.entity;
                Context context = aspect.context.ValueRW;
                DynamicBuffer<StatefulCollisionEvent> buffer = aspect.statefulCollisionEvents;
                int surfaceCount = 0;

                if (!buffer.IsEmpty)
                {
                    //Debug.Log("2");
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        //Debug.Log("3");
                        StatefulCollisionEvent collisionEvent = buffer[i];
                        Entity environmentEntity = collisionEvent.GetOtherEntity(affectedEntity);

                        if (SystemAPI.HasComponent<SurfaceTag>(environmentEntity))
                            surfaceCount++;
                    }
                }

                aspect.context.ValueRW.onSurface = surfaceCount > 0;
            }
        }
    }
}

