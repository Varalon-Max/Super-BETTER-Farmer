using System;
using System.Diagnostics;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private AnimalSpawner _spawner;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            _spawner.SpawnTier(1);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            _spawner.SpawnTier(2);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            _spawner.SpawnTier(3); 
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            _spawner.SpawnTier(4);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            _spawner.SpawnTier(5);
        }
    }
}