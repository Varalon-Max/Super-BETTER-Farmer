using System.Collections;
using System.Collections.Generic;
using SpawnHandler;
using TurnHandler.TwoPlayers;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> animalsList;

    [SerializeField] private TextHandler _textHandler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFirstTier()
    {
        GameObject firstTierSpawner = GameObject.FindWithTag("T1Spawner");
        var position = firstTierSpawner.transform.position;
        Instantiate(animalsList[0], 
            position,
            firstTierSpawner.transform.rotation,
            firstTierSpawner.transform);
        _textHandler.IncreaseNumber(0, firstTierSpawner.transform.childCount);

    }

    public void SpawnSecondTier()
    {
        GameObject secondTierSpawner = GameObject.FindWithTag("T2Spawner");
        var position = secondTierSpawner.transform.position;
        Instantiate(animalsList[1], 
            position,
            secondTierSpawner.transform.rotation,
            secondTierSpawner.transform);
        _textHandler.IncreaseNumber(1, secondTierSpawner.transform.childCount);
    }

    public void SpawnThirdTier()
    {
        GameObject thirdTierSpawner = GameObject.FindWithTag("T3Spawner");
        var position = thirdTierSpawner.transform.position;
        Instantiate(animalsList[2], 
            position,
            thirdTierSpawner.transform.rotation,
            thirdTierSpawner.transform);
        _textHandler.IncreaseNumber(2, thirdTierSpawner.transform.childCount);
    }

    public void SpawnFourthTier()
    {
        GameObject fourthTierSpawner = GameObject.FindWithTag("T4Spawner");
        var position = fourthTierSpawner.transform.position;
        Instantiate(animalsList[3], 
            position,
            fourthTierSpawner.transform.rotation,
            fourthTierSpawner.transform);
        _textHandler.IncreaseNumber(3, fourthTierSpawner.transform.childCount);
    }

    public void SpawnFifthTier()
    {
        GameObject fifthTierSpawner = GameObject.FindWithTag("T5Spawner");
        var position = fifthTierSpawner.transform.position;
        Instantiate(animalsList[4], 
            position,
            fifthTierSpawner.transform.rotation,
            fifthTierSpawner.transform);
        _textHandler.IncreaseNumber(4, fifthTierSpawner.transform.childCount);
    }
}
