using Unity.Entities;

/*
 * Summary
 * This system chooses, which speed parametr should use mover, based on entity state
 */
namespace TIC.FunnyStarts
{
    public partial class SpeedGetter : SystemBase
    {
        //Simplified version of system, need connection with fsm
        protected override void OnUpdate()
        {
            foreach (SpeedGetterAspect speedGetterAspect in SystemAPI.Query<SpeedGetterAspect>())
            {
                speedGetterAspect.currentMoveSpeed.ValueRW.value = speedGetterAspect.speedParametrs.ValueRO.surfaceSpeedParametr;
            }
        }
    }
}

