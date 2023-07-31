using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;


namespace TIC.FunnyStarts
{
    public struct PlayerTag : IComponentData {}
    public struct RequestTag : IComponentData {}
    public struct AffectedByContextTag : IComponentData { }
    public struct SurfaceTag : IComponentData { }  
    public struct CoverTriggerTag : IComponentData { }
    public struct WallTriggerTag : IComponentData { }
}
    
