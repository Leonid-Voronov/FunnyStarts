using System.Collections;
using System.Collections.Generic;
using TIC.FunnyStarts;
using Unity.Entities;
using UnityEngine;

public readonly partial struct SpeedGetterAspect : IAspect
{
    public readonly RefRO<SpeedParametrs> speedParametrs;
    public readonly RefRW<CurrentMoveSpeed> currentMoveSpeed;
}
