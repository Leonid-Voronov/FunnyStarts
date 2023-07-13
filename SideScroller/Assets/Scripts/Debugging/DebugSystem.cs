using System.Collections;
using System.Collections.Generic;
using TIC.FunnyStarts;
using Unity.Entities;
using UnityEngine;

public partial class DebugSystem : SystemBase
{
    protected override void OnUpdate()
    {
        foreach (var jumpRequest in SystemAPI.Query<JumpRequest>()) 
        {
            Debug.Log("ww");
        }
    }
}
