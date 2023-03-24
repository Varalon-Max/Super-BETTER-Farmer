using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DiceMechanics
{
    public class DiceController : MonoBehaviour
    {
        [SerializeField] private GameObject dice;

        [SerializeField] private GameObject side;

        [SerializeField] private Vector3 spawnCoordinates;
        [SerializeField] private float forceModifier;
        [SerializeField] private float torqueModifier;

        private void Awake()
        {
        }

        private void Start()
        {
            //side.transform.SetParent(dice.transform);
           // RollDice();
            RollDice();
        }

        private void RollDice()
        {
             var diceObj = Instantiate(dice, spawnCoordinates + new Vector3(Random.value, Random.value, Random.value),
                 Quaternion.identity);

           // var diceObj = Instantiate(dice);
            var rigidbody = diceObj.GetComponent<Rigidbody>();

           // rigidbody.AddTorque(new Vector3(Random.value, Random.value, Random.value) * torqueModifier,
            //    ForceMode.Impulse);
           // rigidbody.AddForce(new Vector3(Random.value, 0, Random.value) * forceModifier, ForceMode.Impulse);
        }

        private void AddChildrenToDices()
        {
        }
    }
}