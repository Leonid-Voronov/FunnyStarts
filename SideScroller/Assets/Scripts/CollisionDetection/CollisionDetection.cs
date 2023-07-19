using Events;
using System.Collections;
using System.Collections.Generic;
using TIC.FunnyStarts;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Stateful;
using UnityEngine;
using UnityEngine.ProBuilder;

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
                    if (statefulCollisionEvent.State != StatefulEventState.Enter) continue;

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
