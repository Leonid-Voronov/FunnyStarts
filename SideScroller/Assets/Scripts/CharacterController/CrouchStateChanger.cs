using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public partial class CrouchStateChanger : SystemBase
    {
        protected override void OnUpdate()
        {
            foreach (var crouchRequest in SystemAPI.Query<CrouchRequest>())
            {

                Entity playerEntity = crouchRequest.playerEntity;
                RefRW<Context> context = SystemAPI.GetComponentRW<Context>(playerEntity);

                if (context.ValueRO.onSurface)
                    context.ValueRW.inCrouch = !context.ValueRW.inCrouch;
            }
        }
    }
}

