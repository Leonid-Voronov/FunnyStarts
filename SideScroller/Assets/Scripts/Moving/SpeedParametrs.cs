using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public struct SpeedParametrs : IComponentData
    {
        public float surfaceSpeedParametr;
        public float climbSpeedParametr;
        public float coverSpeedParametr;
    }
}
