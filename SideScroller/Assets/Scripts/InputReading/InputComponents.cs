using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;


namespace TIC.FunnyStarts
{
    public struct InputDirection : IComponentData
    {
        public float2 value;
    }

    public struct InputSprint : IComponentData
    {
        public float value;
    }

    public struct InputCrouch : IComponentData
    {
        public float value;
    }

    public struct InputAim : IComponentData
    {
        public float value;
    }

    public struct InputJumpHold : IComponentData
    {
        public float value;
    }

    public struct InputBlock : IComponentData 
    { 
        public float value; 
    }
}

