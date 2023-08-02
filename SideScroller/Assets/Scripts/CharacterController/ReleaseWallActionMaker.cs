using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public partial class ReleaseWallActionMaker : SystemBase
    {
        protected override void OnUpdate()
        {
            foreach (var crouchRequest in SystemAPI.Query<CrouchRequest>())
            {
                Debug.Log("CrouchRequest");
                Entity playerEntity = crouchRequest.playerEntity;
                RefRW<Context> context = SystemAPI.GetComponentRW<Context>(playerEntity);

                context.ValueRW.releasedWall = !context.ValueRW.releasedWall;
            }
        }
    }
}

