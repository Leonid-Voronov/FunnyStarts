using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Systems;
using UnityEngine;


namespace TIC.FunnyStarts
{
    [UpdateInGroup(typeof(PhysicsSystemGroup))]
    [UpdateAfter(typeof(PhysicsSimulationGroup))]
    public partial struct TouchSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<SimulationSingleton>();
            state.RequireForUpdate<EndSimulationEntityCommandBufferSystem.Singleton>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            state.Dependency = new CollisionJob()
            {
                TouchLookup = SystemAPI.GetComponentLookup<Touch>(true),
                VelocityLookup = SystemAPI.GetComponentLookup<PhysicsVelocity>(true),
                CommandBuffer = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
                                         .CreateCommandBuffer(state.WorldUnmanaged)
            }.Schedule(SystemAPI.GetSingleton<SimulationSingleton>(), state.Dependency);

            
        }

        [BurstCompile]
        private struct CollisionJob : ICollisionEventsJob
        {
            [Unity.Collections.ReadOnly] public ComponentLookup<Touch> TouchLookup;
            [Unity.Collections.ReadOnly] public ComponentLookup<PhysicsVelocity> VelocityLookup;

            public EntityCommandBuffer CommandBuffer;

            private bool IsDynamic(Entity entity) => VelocityLookup.HasComponent(entity);
            private bool IsTouchable(Entity entity) => TouchLookup.HasComponent(entity);

            public void Execute(CollisionEvent collisionEvent)
            {
                var entityA = collisionEvent.EntityA;
                var entityB = collisionEvent.EntityB;

                if (IsTouchable(entityA) && IsDynamic(entityB))
                {
                    CommandBuffer.AddComponent(entityA, new Touched(entityB, collisionEvent.Normal));
                }
                else
                if (IsTouchable(entityB) && IsDynamic(entityA))
                {
                    CommandBuffer.AddComponent(entityB, new Touched(entityA, collisionEvent.Normal));
                }
            }
        }
    }

}

