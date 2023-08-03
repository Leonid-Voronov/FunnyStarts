using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class SpeedParametrsAuthoring : MonoBehaviour
    {
        public float surfaceSpeed;
        public float climbSpeed;
        public float coverSpeed;
        public float fellSpeed;
    }

    public class SpeedParametrsBaker : Baker<SpeedParametrsAuthoring>
    {
        public override void Bake(SpeedParametrsAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            SpeedParametrs component = new SpeedParametrs()
            {
                surfaceSpeedParametr = authoring.surfaceSpeed,
                climbSpeedParametr = authoring.climbSpeed,
                coverSpeedParametr = authoring.coverSpeed,
                fellSpeedParametr = authoring.fellSpeed
            };
            AddComponent(entity, component);
        }
    }
}



