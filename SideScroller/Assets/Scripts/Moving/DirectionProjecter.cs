using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.ProBuilder;

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
                Context context = directionProjectionAspect.context.ValueRO;
                float2 inputDirectionValue = directionProjectionAspect.inputDirection.ValueRO.value;
                float3 forward = new float3(inputDirectionValue.x, 0.0f, inputDirectionValue.y);

                if (context.climbing && !context.inJumpStartPhase)
                {
                    float3 normal = directionProjectionAspect.surfaceNormal.ValueRO.value;

                    if (normal.x < 0.5f)
                        forward = new float3(inputDirectionValue.x, inputDirectionValue.y, 0.0f);
                    else
                        forward = new float3(0.0f, inputDirectionValue.y, inputDirectionValue.x);

                    directionProjectionAspect.movingDirection.ValueRW.value = forward - math.dot(forward, normal) * normal;
                }
                else if (context.inJump)
                {
                    float3 upDirection = new float3(0, 1f, 0);
                    directionProjectionAspect.movingDirection.ValueRW.value = forward + upDirection;
                }
                else if (context.onSurface)
                {
                    float3 normal = directionProjectionAspect.surfaceNormal.ValueRO.value;
                    directionProjectionAspect.movingDirection.ValueRW.value = forward - math.dot(forward, normal) * normal;
                }
                else if (!context.inUnfellableAction)
                {
                    float3 downDirection = new float3(0, -1f, 0);
                    directionProjectionAspect.movingDirection.ValueRW.value = forward + downDirection;
                }
            }
        }
    }


}

