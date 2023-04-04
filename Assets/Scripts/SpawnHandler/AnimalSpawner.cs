using System.Collections.Generic;
using UnityEngine;

namespace SpawnHandler
{
    public class AnimalSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _spawners;

        [SerializeField] private List<GameObject> _animalTokens;
        [SerializeField] private float _spawnersOffset;

        public void SpawnTier(int numberOfTier)
        {
            int numberOfSpawners = 6 - numberOfTier;
            int spawnTier = numberOfTier - 1;

            if (_spawners[spawnTier].transform.childCount<numberOfSpawners)
            {
                Instantiate(_animalTokens[spawnTier],
                    _spawners[spawnTier].transform.position +new Vector3(_spawnersOffset*_spawners[spawnTier].transform.childCount, 0,0),
                    Quaternion.Euler(0,90,90), 
                    _spawners[spawnTier].transform);
            }
        }
    }
}
