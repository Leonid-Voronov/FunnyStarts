using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public struct Context : IComponentData
    {
        [Header("Collisions")]
        public bool onSurface;

        [Header("Triggers")]
        public bool nearCover;
        public bool nearWall;
        public bool nearEdge;
        public bool onEdge;
        public bool onVerticalPlane;
    }
}
