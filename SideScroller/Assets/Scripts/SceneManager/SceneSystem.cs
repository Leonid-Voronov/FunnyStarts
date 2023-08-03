using Unity.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TIC.FunnyStarts
{
    public partial class SceneSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            LoadScene();
        }

        private void LoadScene()
        {
            foreach (var request in SystemAPI.Query<RefRO<ReloadSceneRequest>>())
            {
                SceneManager.LoadScene(request.ValueRO.sceneNubmer);
                return;
            }
        }
    }
}