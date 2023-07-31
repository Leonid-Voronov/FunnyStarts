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
    }

    public partial class CollisionDetection : SystemBase
    {
        private EntityCommandBuffer entityCommandBuffer;
        private int surfaceCount = 0;
        protected override void OnCreate()
        {
            RequireForUpdate<StatefulCollisionEvent>();
        }
        protected override void OnUpdate()
        {
            foreach (var aspect in SystemAPI.Query<AffectedByContextAspect>())
            {
                Entity affectedEntity = aspect.entity;
                Context context = aspect.context.ValueRW;
                DynamicBuffer<StatefulCollisionEvent> buffer = aspect.statefulCollisionEvents;
                surfaceCount = 0;

                if (!buffer.IsEmpty)
                {
                    for (int i = 0; i < buffer.Length; i++)
                    {
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

