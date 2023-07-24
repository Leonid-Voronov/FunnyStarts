using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    public class InputSprintAuthoring : MonoBehaviour
    {

    }

    public class InputSprintBaker : Baker<InputSprintAuthoring>
    {
        public override void Bake(InputSprintAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            InputSprint inputSprint = new InputSprint();
            AddComponent(entity, inputSprint);
        }
    }
}
