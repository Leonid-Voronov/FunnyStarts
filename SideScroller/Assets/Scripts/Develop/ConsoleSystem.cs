using System;
using System.Collections.Generic;
using TIC.FunnyStarts;
using Unity.Entities;
using UnityEngine.SceneManagement;

namespace Develop
{
    public partial class ConsoleSystem : SystemBase
    {
        public string conoleCommandName = null;
        public string error = null;
        private List<(string, Action)> _commandList;
        

        protected override void OnCreate()
        {
            _commandList = new List<(string, Action)>()
            {
                ("reloadScene", delegate { OnReloadScene();}),
            };
        }

        protected override void OnUpdate()
        {
            foreach (var tuple in _commandList)
            {
                if (tuple.Item1 == conoleCommandName)
                {
                    tuple.Item2.Invoke();
                    conoleCommandName = null;
                    return;
                }
            }            
        }
        
        void OnReloadScene()
        {
            var ent = EntityManager.CreateEntity();
            var request = new ReloadSceneRequest
            {
                sceneNubmer = SceneManager.GetActiveScene().buildIndex,
            };
            EntityManager.AddComponentData<ReloadSceneRequest>(ent, request);
            EntityManager.AddComponent<RequestTag>(ent);
        }
    }
    
}