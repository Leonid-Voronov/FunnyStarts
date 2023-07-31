using TIC.FunnyStarts;
using Unity.Entities;

namespace TIC.FunnyStarts
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial class ContextColorInterpretation : SystemBase
    {
        protected override void OnUpdate()
        {
            var ecbSingleton = SystemAPI.GetSingleton<BeginPresentationEntityCommandBufferSystem.Singleton>();
            EntityCommandBuffer ecb = ecbSingleton.CreateCommandBuffer(World.Unmanaged);

            foreach (var context in SystemAPI.Query<RefRO<Context>>())
            {
                Entity newRequest = ecb.CreateEntity();
                ColorName newColor = ColorName.Horizontal;

                if (context.ValueRO.nearWall)
                {
                    newColor = ColorName.HorizontalNearWall;
                }
                else if (context.ValueRO.nearCover)
                {
                    newColor = ColorName.HorizontalNearCover;
                }
                else if (context.ValueRO.nearEdge)
                {
                    newColor = ColorName.HorizontalNearEdge;
                }
                else if (context.ValueRO.onEdge)
                {
                    newColor = ColorName.Edge;
                }
                else if (context.ValueRO.onVerticalPlane)
                {
                    newColor = ColorName.Vertical;
                }
                else if (context.ValueRO.onSurface)
                {
                    newColor = ColorName.Horizontal; //Should be after all triggers
                }
                else
                {
                    newColor = ColorName.Air; //Should be last
                }

                ecb.AddComponent<ColorChangingRequest>(newRequest);
                ecb.SetComponent<ColorChangingRequest>(newRequest, new ColorChangingRequest() { colorName = newColor });
            }
        }
    }
}

