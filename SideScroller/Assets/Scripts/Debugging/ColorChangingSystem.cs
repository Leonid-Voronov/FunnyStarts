using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Rendering;
using UnityEngine;
using Unity.Mathematics;
using Unity.Collections;

namespace TIC.FunnyStarts
{
    public enum ColorName
    {
        Horizontal,
        Air,
        Edge,
        HalfHeightCover,
        HeightCover,
        HorizontalNearCover,
        HorizontalNearEdge,
        HorizontalNearWall,
        Vertical,
        WallCover
    }

    /*
     * Summary
     * This system changes color of playerEntity based on ColorChangingRequests
     */
    [UpdateInGroup(typeof(PresentationSystemGroup), OrderLast = true)]
    public partial class ColorChangingSystem : SystemBase
    {
        private Dictionary<ColorName, float4> keyValuePairs = new Dictionary<ColorName, float4>();
        private Entity _playerEntity;
        private EntityCommandBuffer ecb;
        protected override void OnStartRunning()
        {
            keyValuePairs.Add(ColorName.Horizontal,             new float4 (1,         1, 1, 1));
            keyValuePairs.Add(ColorName.Air,                    new float4 (1,         0, 1, 1));
            keyValuePairs.Add(ColorName.HalfHeightCover,        new float4 (0.2901f,   0.5254f, 0.9098f, 1));
            keyValuePairs.Add(ColorName.WallCover,              new float4 (0.6f,      0, 1, 1));
            keyValuePairs.Add(ColorName.HeightCover,            new float4 (0,         0, 1, 1));
            keyValuePairs.Add(ColorName.Vertical,               new float4 (0.8784f,   0.4f, 0.4f, 1));
            keyValuePairs.Add(ColorName.HorizontalNearCover,    new float4 (0.6509f,   0.3019f, 0.4715f, 1));
            keyValuePairs.Add(ColorName.Edge,                   new float4 (0.9647f,   0.6980f, 0.4196f, 1));
            keyValuePairs.Add(ColorName.HorizontalNearEdge,     new float4 (0.7607f,   0.4823f, 0.6274f, 1));
            keyValuePairs.Add(ColorName.HorizontalNearWall,     new float4 (0.4039f,   0.3058f, 0.6549f, 1));


            _playerEntity = SystemAPI.GetSingletonEntity<PlayerTag>();
        }
        protected override void OnUpdate()
        {
            foreach (var colorChangingRequest in SystemAPI.Query<ColorChangingRequest>()) 
            {
                URPMaterialPropertyBaseColor newColor = new URPMaterialPropertyBaseColor() { Value = GetNewColor(colorChangingRequest.colorName) };
                SystemAPI.SetComponent<URPMaterialPropertyBaseColor>(_playerEntity, newColor);
            }
        }

        protected override void OnStopRunning()
        {
            _playerEntity = Entity.Null;
        }

        private float4 GetNewColor (ColorName colorName)
        {
            return keyValuePairs[colorName];
        }
    }

}
