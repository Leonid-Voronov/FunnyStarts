using Unity.Entities;

namespace TIC.FunnyStarts
{
    public struct SpeedParametrs : IComponentData
    {
        public float surfaceSpeedParametr;
        public float climbSpeedParametr;
        public float coverSpeedParametr;
    }
}
