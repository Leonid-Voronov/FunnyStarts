using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Stateful;
using UnityEngine.ProBuilder;

namespace TIC.FunnyStarts
{
    /*
    * Summary
    * This system writes normal to PhysicsBody entity OnCollisionEvent between PhysicsShape entities and PhysicsBody entities
    */
    public partial class NormalWriter : SystemBase
    {
        protected override void OnCreate()
        {
            RequireForUpdate<StatefulCollisionEvent>();
        }
        protected override void OnUpdate()
        {
            foreach (var buffer in SystemAPI.Query<DynamicBuffer<StatefulCollisionEvent>>())
            {
                if (!buffer.IsEmpty)
                {
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        var statefulCollisionEvent = buffer[i];
                        float3 normal = statefulCollisionEvent.Normal;
                        
                        WriteNormalToComponent(GetPVEntity(statefulCollisionEvent), normal);
                    }
                }
            }
        }

        private void WriteNormalToComponent(Entity entity, float3 newNormal)
        {
            if (SystemAPI.HasComponent<SurfaceNormal>(entity))
            {
                RefRW<SurfaceNormal> surfaceNormal = SystemAPI.GetComponentRW<SurfaceNormal>(entity);
                surfaceNormal.ValueRW.value = newNormal;
            }
        }

        //Get Entity with Physics Velocity component
        private Entity GetPVEntity(StatefulCollisionEvent collisionEvent)
        {
            bool a = SystemAPI.HasComponent<PhysicsVelocity>(collisionEvent.EntityA);
            bool b = SystemAPI.HasComponent<PhysicsVelocity>(collisionEvent.EntityB);

            if (a)
                return collisionEvent.EntityA;
            else if (b)
                return collisionEvent.EntityB;
            else
                return Entity.Null;
        }

        private bool IsNormalHorizontal(float3 normal)
        {
            return math.abs(normal.x) < 0.5f && math.abs(normal.z) < 0.5f;
        }
    }
}

