using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public readonly partial struct DirectionProjectionAspect : IAspect
    {
        public readonly RefRO<InputDirection> inputDirection;
        public readonly RefRO<SurfaceNormal> surfaceNormal;
        public readonly RefRW<MovingDirection> movingDirection;
    }
}
