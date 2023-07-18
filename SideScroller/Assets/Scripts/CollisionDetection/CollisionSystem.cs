using Unity.Physics;
using Unity.Entities;
using Unity.Physics.Systems;
using UnityEngine;
using Unity.Burst;

namespace TIC.FunnyStarts
{
    [UpdateInGroup(typeof(PhysicsSystemGroup))]
    [UpdateAfter(typeof(PhysicsSimulationGroup))]
    public partial struct CollisionSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<SimulationSingleton>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state) 
        {
            state.Dependency = new CollisionJob().Schedule( SystemAPI.GetSingleton<SimulationSingleton>(), state.Dependency );
        }

        [BurstCompile]
        private struct CollisionJob : ICollisionEventsJob
        {
            public void Execute(CollisionEvent collisionEvent)
            {
                Debug.Log($"A: {collisionEvent.EntityA}, B: {collisionEvent.EntityB}");
            }
        }
    }
}
