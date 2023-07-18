using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public struct Touch : IComponentData
    {}

    public readonly struct Touched : IComponentData
    {
        public readonly Entity Who;
        public readonly float3 Normal;

        public Touched(Entity who, float3 normal)
        {
            Who = who;
            Normal = normal;
        }
    }
}

