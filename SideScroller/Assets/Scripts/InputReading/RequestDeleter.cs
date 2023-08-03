using System.Collections;
using System.Collections.Generic;
using TIC.FunnyStarts;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    /*
     * Summary
     * This system deletes requests at init of every frame
     */

    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = false)]
    public partial class RequestDeleter : SystemBase
    {
        protected override void OnCreate()
        {
            RequireForUpdate<RequestTag>();
        }

        protected override void OnUpdate()
        {
            EntityQuery requests = GetEntityQuery(ComponentType.ReadOnly<RequestTag>());
            EntityManager.DestroyEntity(requests);
        }
    }
}


