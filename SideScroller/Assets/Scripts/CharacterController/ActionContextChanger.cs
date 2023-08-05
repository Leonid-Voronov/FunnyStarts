using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public partial class ActionContextChanger : SystemBase
    {
        protected override void OnUpdate()
        {
            EntityQuery unfellableActions = GetEntityQuery(ComponentType.ReadOnly<UnfellableActionTag>());
            EntityQuery jumpActions = GetEntityQuery(ComponentType.ReadOnly<FiniteAction>(), ComponentType.ReadOnly<JumpData>());

            foreach (var context in SystemAPI.Query<RefRW<Context>>())
            {
                context.ValueRW.inUnfellableAction = unfellableActions.CalculateEntityCount() > 0;
                context.ValueRW.inJump = jumpActions.CalculateEntityCount() > 0;

                bool jumpActionStartPass = true;
                if (context.ValueRW.inJump)
                {
                    FiniteAction finiteAction = jumpActions.GetSingleton<FiniteAction>();
                    context.ValueRW.inJumpStartPhase = finiteAction.timer >= (.75f) *(finiteAction.time);
                    jumpActionStartPass = !(finiteAction.timer < .75f * finiteAction.time);
                }

                context.ValueRW.climbing = context.ValueRO.onVerticalPlane && !context.ValueRO.releasedWall && !context.ValueRO.onSurface && jumpActionStartPass;
                context.ValueRW.holdingEdge = context.ValueRO.onEdge && !context.ValueRO.releasedWall && jumpActionStartPass;
                context.ValueRW.releasedWall = context.ValueRW.releasedWall && !context.ValueRO.onSurface;

                context.ValueRW.inCrouch = context.ValueRW.inCrouch && context.ValueRW.onSurface;
            }
        }
    }
}

