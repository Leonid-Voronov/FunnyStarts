using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Entities;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace TIC.FunnyStarts
{
    public class PlayerTagAuthoring : MonoBehaviour
    {

    }

    public class PlayerTagBaker : Baker<PlayerTagAuthoring>
    {
        public override void Bake(PlayerTagAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            PlayerTag component = new PlayerTag();
            AddComponent(entity, component);
        }
    }
}

