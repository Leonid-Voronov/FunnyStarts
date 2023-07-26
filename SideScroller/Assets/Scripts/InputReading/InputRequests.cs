using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.InputSystem;

namespace TIC.FunnyStarts
{
    /*
     * This file declare requests for certain inputs
     */

    public struct JumpRequest : IComponentData
    {
        public Entity playerEntity;
    }

    public struct ShootRequest : IComponentData
    {
        public Entity playerEntity;
    }

    public struct ReloadRequest : IComponentData
    {
        public Entity playerEntity;
    }
}

