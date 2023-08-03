using System.Collections;
using System.Collections.Generic;
using TIC.FunnyStarts;
using Unity.Entities;
using UnityEngine;

public partial class DebugSystem : SystemBase
{
    protected override void OnStartRunning()
    {
        //DebugOnStart();
    }

    protected override void OnUpdate()
    {
        foreach (var reloadRequest in SystemAPI.Query<ReloadRequest>()) 
        {
            //Debug.Log(reloadRequest.playerEntity);  
        }
    }

    private void DebugOnStart()
    {
        Entity newEntity = EntityManager.CreateEntity();
        ColorChangingRequest request = new ColorChangingRequest() { colorName = ColorName.Air };
        EntityManager.AddComponentData(newEntity, request);
        EntityManager.AddComponent<RequestTag>(newEntity);
    }
}
