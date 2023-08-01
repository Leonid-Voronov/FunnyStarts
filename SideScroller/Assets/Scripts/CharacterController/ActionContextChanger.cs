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

            foreach (var context in SystemAPI.Query<RefRW<Context>>())
            {
                context.ValueRW.inUnfellableAction = unfellableActions.CalculateEntityCount() > 0;
            }
        }
    }
}

