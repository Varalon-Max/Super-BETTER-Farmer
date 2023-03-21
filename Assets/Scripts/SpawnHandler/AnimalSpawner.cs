using System.Collections;
using System.Collections.Generic;
using SpawnHandler;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _firstTierSpawners;
    [SerializeField] private List<GameObject> _secondTierSpawners;
    [SerializeField] private List<GameObject> _thirdTierSpawners;
    [SerializeField] private List<GameObject> _fourthTierSpawners;
    [SerializeField] private List<GameObject> _fifthTierSpawners;

    [SerializeField] private List<GameObject> _animalTokens;

    public void SpawnTier(int numberOfTier)
    {
        switch (numberOfTier)
        {
            case 1:
                foreach (var spawner in _firstTierSpawners)
                {
                    if (spawner.transform.childCount == 0)
                    {
                        Instantiate(_animalTokens[0], spawner.transform.position, spawner.transform.rotation,
                            spawner.transform);
                        break;
                    }
                }
                Debug.Log("Add to counter");
                break;
            case 2:
                foreach (var spawner in _secondTierSpawners)
                {
                    if (spawner.transform.childCount == 0)
                    {
                        Instantiate(_animalTokens[0], spawner.transform.position, spawner.transform.rotation,
                            spawner.transform);
                        break;
                    }
                }
                Debug.Log("Add to counter");
                break;
            case 3:
                foreach (var spawner in _thirdTierSpawners)
                {
                    if (spawner.transform.childCount == 0)
                    {
                        Instantiate(_animalTokens[0], spawner.transform.position, spawner.transform.rotation,
                            spawner.transform);
                        break;
                    }
                }
                Debug.Log("Add to counter");
                break;
            case 4:
                foreach (var spawner in _fourthTierSpawners)
                {
                    if (spawner.transform.childCount == 0)
                    {
                        Instantiate(_animalTokens[0], spawner.transform.position, spawner.transform.rotation,
                            spawner.transform);
                        break;
                    }
                }
                Debug.Log("Add to counter");
                break;
            case 5:
                foreach (var spawner in _fifthTierSpawners)
                {
                    if (spawner.transform.childCount == 0)
                    {
                        Instantiate(_animalTokens[0], spawner.transform.position, spawner.transform.rotation,
                            spawner.transform);
                        break;
                    }
                }
                Debug.Log("Add to counter");
                break;
        }
    }

    
}
