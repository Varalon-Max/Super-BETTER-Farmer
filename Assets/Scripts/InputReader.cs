using System;
using System.Diagnostics;
using DefaultNamespace;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private BoardBrain _boardBrain;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            _boardBrain.SpawnToken(1);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            _boardBrain.SpawnToken(2);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            _boardBrain.SpawnToken(3); 
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            _boardBrain.SpawnToken(4);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            _boardBrain.SpawnToken(5);
        }
    }
}