using System.Collections;
using System.Collections.Generic;
using TIC.FunnyStarts;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = false)]
    public partial class InputRequestDeleter : SystemBase
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


