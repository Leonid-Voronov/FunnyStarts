using Unity.Entities;
using Unity.Physics;

namespace TIC.FunnyStarts
{
    public readonly partial struct MoveAspect : IAspect
    {
        public readonly RefRO<MovingDirection> movingDirection;
        public readonly RefRO<CurrentMoveSpeed> currentMoveSpeed;
        public readonly RefRW<PhysicsVelocity> physicsVelocity;
    }
}

