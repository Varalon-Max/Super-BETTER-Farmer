using SpawnHandler;
using UnityEngine;

namespace DefaultNamespace
{
    public class BoardBrain : MonoBehaviour
    {
        [SerializeField] private AnimalSpawner _animalSpawner;
        [SerializeField] private TextHandler _textHandler;

        public void SpawnToken(int spawnTier)
        {
            
            _animalSpawner.SpawnTier(spawnTier);
            _textHandler.IncreaseNumber(spawnTier);
        }
    }
}