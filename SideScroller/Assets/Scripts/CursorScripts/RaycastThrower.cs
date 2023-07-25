using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Unity.Physics;

namespace TIC.FunnyStarts
{
    public partial class RaycastThrower : SystemBase
    {
        protected override void OnUpdate()
        {
            PhysicsWorld world = SystemAPI.GetSingletonRW<PhysicsWorldSingleton>().ValueRW.PhysicsWorld;
            Camera cam = Camera.main;
            foreach (var shootRequest in SystemAPI.Query<RefRO<ShootRequest>>())
            {
                if (cam == null)
                    return;
                var mul = cam.farClipPlane / cam.nearClipPlane;
                var wp = SystemAPI.GetSingleton<WorldCursorPosition>()._worldCursorPosition;
                var start = (float3)cam.transform.position;
                var difX = mul * (wp.x - start.x);
                var difY = mul * (wp.y - start.y);
                var end = new float3(difX, difY, cam.farClipPlane);
                
                Debug.Log(start);
                
                
                var input = new RaycastInput()
                {
                    Start = start,
                    Filter = CollisionFilter.Default,
                    End = end,
                };
                var hit = world.CastRay(input, out var rayResult);
                var ditPos = math.select(input.End, rayResult.Position, hit);
                Debug.DrawRay(input.Start,   input.End - input.Start);
               
            }
        }
    }
}