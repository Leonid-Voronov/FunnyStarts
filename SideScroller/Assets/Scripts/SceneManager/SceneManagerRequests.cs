using Unity.Entities;

namespace TIC.FunnyStarts
{
    public struct ReloadSceneRequest : IComponentData
    {
        public int sceneNubmer;
    }
}