using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace TIC.FunnyStarts
{
    /*Summary
     * Component stores normal of surface, on which entity is standing
     */
    public struct SurfaceNormal : IComponentData
    {
        public float3 value;
    }
}

