using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public struct FiniteAction : IComponentData
    {
        public float time;
        public float timer;
    }
}

