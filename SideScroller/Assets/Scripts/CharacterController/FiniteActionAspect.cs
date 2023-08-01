using Unity.Entities;

namespace TIC.FunnyStarts
{
    public readonly partial struct FiniteActionAspect : IAspect
    {
        public readonly Entity entity;

        public readonly RefRW<FiniteAction> finiteAction; 
    }
}

