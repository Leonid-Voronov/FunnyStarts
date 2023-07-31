using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public struct Context : IComponentData
    {
        public bool onSurface;
    }
}
