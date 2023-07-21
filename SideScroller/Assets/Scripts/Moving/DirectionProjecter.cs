using Unity.Entities;
using Unity.Mathematics;

namespace TIC.FunnyStarts
{
    /*
     * Summary
     * This system calculates direcion of moving for entities on surfaces based on InputDirection and Surface normal
     */
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial class DirectionProjecter : SystemBase
    {
        protected override void OnCreate()
        {
            RequireForUpdate<InputDirection>();
            RequireForUpdate<SurfaceNormal>();
            RequireForUpdate<MovingDirection>();
        }

        protected override void OnUpdate()
        {
            foreach (DirectionProjectionAspect directionProjectionAspect in SystemAPI.Query<DirectionProjectionAspect>())
            {
                float2 inputDirectionValue = directionProjectionAspect.inputDirection.ValueRO.value;
                float3 forward = new float3(inputDirectionValue.x, 0.0f, inputDirectionValue.y);
                float3 normal = directionProjectionAspect.surfaceNormal.ValueRO.value;

                directionProjectionAspect.movingDirection.ValueRW.value = forward - math.dot(forward, normal) * normal;
            }
        }
    }
}

