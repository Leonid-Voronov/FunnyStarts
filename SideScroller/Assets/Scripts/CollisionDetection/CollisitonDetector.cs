using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Physics;

namespace TIC.FunnyStarts
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial class CollisitonDetector : SystemBase
    {
        protected override void OnUpdate()
        {
            foreach(var (playerTag, collider) in SystemAPI.Query < RefRO<PlayerTag>, RefRW<PhysicsCollider> >())
            {
                BlobAssetReference<Collider> colliderVar = collider.ValueRW.Value;

                //colliderVar.Value.
            }
        }
    }
}

