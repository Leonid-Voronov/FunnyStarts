using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;


namespace TIC.FunnyStarts
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial class DirectionProjecter : SystemBase
    {
        //Add OnCreate somewhere here


        protected override void OnUpdate()
        {
            foreach (var inputDirection in SystemAPI.Query<RefRO<InputDirection>>())
            {
                float2 inputDirectionValue = inputDirection.ValueRO.value;
                float3 forward = new float3 (inputDirectionValue.y, 0.0f, inputDirectionValue.x); //not sure about this line

                //GetNormalOfSurface
            }
        }
    }
}

