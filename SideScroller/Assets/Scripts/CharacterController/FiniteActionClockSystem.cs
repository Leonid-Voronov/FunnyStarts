using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    public partial class FiniteActionClockSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var ecbSingleton = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();
            EntityCommandBuffer ecb = ecbSingleton.CreateCommandBuffer(World.Unmanaged);

            foreach (var finiteActionAspect in SystemAPI.Query<FiniteActionAspect>()) 
            {
                finiteActionAspect.finiteAction.ValueRW.timer -= SystemAPI.Time.DeltaTime;

                if (finiteActionAspect.finiteAction.ValueRO.timer <= 0)
                {
                    ecb.DestroyEntity(finiteActionAspect.entity);
                }
            }    
        }
    }
}

