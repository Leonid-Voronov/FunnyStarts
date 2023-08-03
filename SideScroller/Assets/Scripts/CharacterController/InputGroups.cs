using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace TIC.FunnyStarts
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial class ShootButtonGroup : ComponentSystemGroup { }

    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial class JumpHoldGroup : ComponentSystemGroup  { }

    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial class AimGroup : ComponentSystemGroup { }

    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial class BlockGroup : ComponentSystemGroup { }

    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial class SprintGroup : ComponentSystemGroup { }

    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial class CrouchGroup : ComponentSystemGroup { }
}


