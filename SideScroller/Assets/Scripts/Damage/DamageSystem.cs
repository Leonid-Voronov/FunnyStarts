using Unity.Collections;
using Unity.Entities;

namespace TIC.FunnyStarts
{
    public partial class DamageSystem : SystemBase
    {
        protected override void OnCreate()
        {
            RequireForUpdate<Damageable>();
            RequireForUpdate<DamageRequest>();
        }
        
        protected override void OnUpdate()
        {
            foreach (var damaged in SystemAPI.Query<RefRO<DamageRequest>>())
            {
                var flag = SystemAPI.HasComponent<Damageable>(damaged.ValueRO.damageTarget); //damaged.ValueRO.damageTarget
                if (flag)
                {
                    return;
                }
            }
        }
    }
}