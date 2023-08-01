using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Unity.Physics;
using Unity.Transforms;

namespace TIC.FunnyStarts
{
    [UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
    public partial class RaycastThrower : SystemBase
    {
        private BeginSimulationEntityCommandBufferSystem.Singleton _eecb;
        protected override void OnStartRunning()
        { 
            _eecb =  SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
        }
        protected override void OnUpdate()
        {
            PhysicsWorld world = SystemAPI.GetSingletonRW<PhysicsWorldSingleton>().ValueRW.PhysicsWorld;
            Camera cam = Camera.main;
            //This part make make tranform world cord of screan to , world cord of same point on far plane (equal point)
            foreach (var shootRequest in SystemAPI.Query<RefRO<ShootRequest>>())
            {
                if (cam == null)
                    return;
                var mul = cam.farClipPlane / cam.nearClipPlane;
                var cp = SystemAPI.GetSingleton<CursorPosition>().cursorPosition;
                
                var start = (float3)cam.transform.position;
                
                var difX = mul * (cp.x - start.x);
                var difY = mul * (cp.y - start.y);
                var end = new float3(difX, difY, cam.farClipPlane);
                
                //This part make Raycast Input struct for make raycast in scene
                var input = new RaycastInput()
                {
                    Start = start,
                    Filter = CollisionFilter.Default,
                    End = end,
                };
                
                var hit = world.CastRay(input, out var rayResult);
                var ditPos = math.select(input.End, rayResult.Position, hit);
                
                Debug.DrawRay(input.Start,   input.End - input.Start);

                var rayCastData = new ShootRaycast()
                {
                    target = rayResult.Position,
                    start = SystemAPI.GetComponent<LocalTransform>(shootRequest.ValueRO.playerEntity).Position
                };
                
                var ecb = _eecb.CreateCommandBuffer(World.Unmanaged);
                Entity newEntity = ecb.CreateEntity();
                ecb.AddComponent<RequestTag>(newEntity);
                ecb.AddComponent<ShootRaycast>(newEntity);
                ecb.SetComponent<ShootRaycast>(newEntity, rayCastData);
            }
        }
    }
}