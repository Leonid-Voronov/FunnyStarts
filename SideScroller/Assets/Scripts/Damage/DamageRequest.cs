using Unity.Entities;

namespace TIC.FunnyStarts
{
    public struct DamageRequest : IComponentData
    {
        public Entity damageTarget;
    }
}