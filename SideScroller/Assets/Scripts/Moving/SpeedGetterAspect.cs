using Unity.Entities;

namespace TIC.FunnyStarts
{
    public readonly partial struct SpeedGetterAspect : IAspect
    {
        public readonly RefRO<SpeedParametrs> speedParametrs;
        public readonly RefRW<CurrentMoveSpeed> currentMoveSpeed;
        public readonly RefRO<Context> context;
    }
}

