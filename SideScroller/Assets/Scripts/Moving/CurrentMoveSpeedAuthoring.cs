using Unity.Entities;
using UnityEngine;


namespace TIC.FunnyStarts
{
    public class CurrentMoveSpeedAuthoring : MonoBehaviour
    {
    }

    public class CurrentMoveSpeedBaker : Baker<CurrentMoveSpeedAuthoring>
    {
        public override void Bake(CurrentMoveSpeedAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            CurrentMoveSpeed component = new CurrentMoveSpeed();
            AddComponent(entity, component);
        }
    }
}

