using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial class JumpActionMaker : SystemBase
    {
        private const float jumpTime = .5f; //Get from config file?
        protected override void OnUpdate()
        {
            var ecbSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
            EntityCommandBuffer ecb = ecbSingleton.CreateCommandBuffer(World.Unmanaged);
            EntityQuery currentActions = GetEntityQuery(ComponentType.ReadOnly<FiniteAction>(), ComponentType.ReadOnly<JumpData>());
            
            if (currentActions.CalculateEntityCount() == 0 )
            {
                foreach (var jumpRequest in SystemAPI.Query<JumpRequest>())
                {
                    RefRW<Context> context = SystemAPI.GetComponentRW<Context>(jumpRequest.playerEntity);

                    if (context.ValueRO.onSurface || context.ValueRO.climbing || context.ValueRO.holdingEdge)
                    {
                        Entity newEntity = ecb.CreateEntity();
                        ecb.AddComponent<FiniteAction>(newEntity);
                        ecb.SetComponent(newEntity, new FiniteAction { time = jumpTime, timer = jumpTime });
                        ecb.AddComponent<JumpData>(newEntity);
                        ecb.AddComponent<UnfellableActionTag>(newEntity);

                        //if (context.ValueRW.inCrouch)
                        //    context.ValueRW.inCrouch = false;
                    }
                }
            }
            
        }
    }
}

