using TIC.FunnyStarts;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Stateful;


/*
 * Summary
 * This system detects collision between PhysicsShape entities and PhysicsBody entities
 */
public partial class CollisionDetection : SystemBase
{
    protected override void OnUpdate()
    {
        foreach (var buffer in SystemAPI.Query<DynamicBuffer<StatefulCollisionEvent>>())
        {
            if (!buffer.IsEmpty) 
            {
                for (int i = 0; i < buffer.Length ; i++) 
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
    private Entity GetPVEntity (StatefulCollisionEvent collisionEvent)
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
}
