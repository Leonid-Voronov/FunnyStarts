using Unity.Entities;
using UnityEngine;


namespace TIC.FunnyStarts
{
    public class DamageableAuthoring : MonoBehaviour { }
    public struct Damageable : IComponentData {}
    public class DDamageableBaker : Baker<DamageableAuthoring>
    {
        public override void Bake(DamageableAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            Damageable component = new Damageable();
            AddComponent(entity, component);
        }
    }
}
