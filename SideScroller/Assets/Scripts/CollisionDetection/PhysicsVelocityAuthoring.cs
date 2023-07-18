using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Unity.Physics;
using Unity.Mathematics;


namespace TIC.FunnyStarts
{
    public class PhysicsVelocityAuthoring : MonoBehaviour
    {

    }

    public class PhysicsVelocityBaker : Baker<PhysicsVelocityAuthoring>
    {
        public override void Bake(PhysicsVelocityAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            PhysicsVelocity physicsVelocity = new PhysicsVelocity()
            {
                Linear = new float3(0f, 0f, 0f)
            };
            AddComponent(entity, physicsVelocity);
        }
    }
}



