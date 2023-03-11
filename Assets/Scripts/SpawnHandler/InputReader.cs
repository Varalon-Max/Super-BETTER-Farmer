using System;
using UnityEngine;

namespace SpawnHandler
{
    public class InputReader : MonoBehaviour
    {
        [SerializeField] private AnimalSpawner _spawner;

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                _spawner.SpawnFirstTier();
            }
            if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                _spawner.SpawnSecondTier();
            }
            if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                _spawner.SpawnThirdTier(); 
            }
            if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                _spawner.SpawnFourthTier();
            }
            if (Input.GetKeyUp(KeyCode.Alpha5))
            {
                _spawner.SpawnFifthTier();
            }
        }
    }
}