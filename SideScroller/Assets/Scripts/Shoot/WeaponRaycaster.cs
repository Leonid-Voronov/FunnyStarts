using Unity.Entities;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public  partial class WeaponRaycaster : SystemBase
    {
        private BeginSimulationEntityCommandBufferSystem.Singleton _eecb;
        protected override void OnStartRunning()
        { 
            _eecb =  SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
        }
        
        protected override void OnUpdate()
        {
            PhysicsWorld world = SystemAPI.GetSingletonRW<PhysicsWorldSingleton>().ValueRW.PhysicsWorld;
            foreach (var shootRaycast in SystemAPI.Query<RefRO<ShootRaycast>>())
            {
                var input = new RaycastInput()
                {
                    Start = shootRaycast.ValueRO.start,
                    Filter = CollisionFilter.Default,
                    End = shootRaycast.ValueRO.target,
                };
                
                Debug.Log(shootRaycast.ValueRO.start);
                Debug.Log(shootRaycast.ValueRO.target);
                
                var hit = world.CastRay(input, out var rayResult);
                UnityEngine.Debug.DrawRay(input.Start, input.End - input.Start);
                
                var ecb = _eecb.CreateCommandBuffer(World.Unmanaged);
                Entity newEntity = ecb.CreateEntity();
                DamageRequest damageRequest = new DamageRequest()
                {
                    damageTarget = rayResult.Entity
                };
                ecb.AddComponent<DamageRequest>(newEntity);
                ecb.SetComponent<DamageRequest>(newEntity, damageRequest);
            }
        }
    }
}