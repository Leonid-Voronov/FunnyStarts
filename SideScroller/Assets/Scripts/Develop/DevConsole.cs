using System;
using Develop;
using UnityEngine;
using Unity.Entities;
using TMPro;
using UnityEngine.UIElements;

public class DevConsole : MonoBehaviour
{
    [SerializeReference] TMP_InputField consoleInput;
    private ConsoleSystem _consoleSystem;
    private void Start()
    {
        _consoleSystem = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<ConsoleSystem>();
        consoleInput.onValueChanged.AddListener(delegate(string arg)
        {
            _consoleSystem.conoleCommandName = consoleInput.text;
        });
    }
    // Dev console commands i think or other things 
}
