using System.Collections;
using System.Collections.Generic;
using TIC.FunnyStarts;
using Unity.Entities;
using Unity.Physics.Stateful;
using UnityEngine;

public partial class TriggerDetection : SystemBase
{
    protected override void OnUpdate()
    {
        foreach (var aspect in SystemAPI.Query<AffectedByContextAspect>())
        {
            Entity affectedEntity = aspect.entity;
            Context context = aspect.context.ValueRW;
            DynamicBuffer<StatefulTriggerEvent> buffer = aspect.statefulTriggerEvents;

            int coverTriggerCount = 0;
            int wallTriggerCount = 0;
            int edgeTriggerCount = 0;

            if (!buffer.IsEmpty)
            {
                for (int i = 0; i < buffer.Length; i++)
                {
                    StatefulTriggerEvent triggerEvent = buffer[i];
                    Entity environmentEntity = triggerEvent.GetOtherEntity(affectedEntity);

                    if (SystemAPI.HasComponent<CoverTriggerTag>(environmentEntity))
                        coverTriggerCount++;
                    else if (SystemAPI.HasComponent<WallTriggerTag>(environmentEntity))
                        wallTriggerCount++;
                    else if (SystemAPI.HasComponent<EdgeTriggerTag>(environmentEntity))
                        edgeTriggerCount++;
                }
            }

            aspect.context.ValueRW.nearCover = coverTriggerCount > 0;
            aspect.context.ValueRW.nearWall = wallTriggerCount > 0;
            aspect.context.ValueRW.nearEdge = edgeTriggerCount > 0;

        }
    }


}
