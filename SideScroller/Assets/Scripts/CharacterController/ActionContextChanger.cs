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
            EntityQuery jumpActions = GetEntityQuery(ComponentType.ReadOnly<JumpData>());

            foreach (var context in SystemAPI.Query<RefRW<Context>>())
            {
                context.ValueRW.inUnfellableAction = unfellableActions.CalculateEntityCount() > 0;
                context.ValueRW.inJump = jumpActions.CalculateEntityCount() > 0;
            }
        }
    }
}

