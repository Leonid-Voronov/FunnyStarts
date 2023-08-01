using Unity.Entities;

namespace TIC.FunnyStarts
{
    public readonly partial struct DirectionProjectionAspect : IAspect
    {
        public readonly RefRO<InputDirection> inputDirection;
        public readonly RefRO<SurfaceNormal> surfaceNormal;
        public readonly RefRW<MovingDirection> movingDirection;
        public readonly RefRO<Context> context;
    }
}
