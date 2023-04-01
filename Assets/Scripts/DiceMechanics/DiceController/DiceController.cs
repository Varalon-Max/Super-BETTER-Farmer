using System.Collections.Generic;
using DiceMechanics.DiceController.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DiceMechanics.DiceController
{
    public class DiceController
    {
        public DiceController(DiceControllerData data, List<DiceScript> dices)
        {
            _data = data;
            _dices = new List<DiceScript>();
            foreach (var dice in dices)
            {
                InitDice(dice);
            }
            SetDicesOff();
        }

        private readonly DiceControllerData _data;

        private readonly List<DiceScript> _dices;

        // public void Initialize()
        // {
        //     foreach (var dice in _dices)
        //     {
        //         
        //     }
        // }
        
        private void InitDice(DiceScript dice)
        {
            var diceObj = Object.Instantiate(dice);
            diceObj.Init();
             
            _dices.Add(diceObj);
        }

        public void RollDices()
        {
            SetDicesOn();
            foreach (var dice in _dices)
            {
                dice.StartRotation();
                RollDice(dice);
            }
        }

        private void SetDicesOff()
        {
            foreach (var dice in _dices)
            {
                dice.gameObject.SetActive(false);
            }
        }

        private void SetDicesOn()
        {
            foreach (var dice in _dices)
            {
                dice.gameObject.SetActive(true);
            }
        }

        private void RollDice(DiceScript dice)
        {
            var rigidbody = dice.Rigidbody;
            
            rigidbody.position = _data.SpawnCoordinates + new Vector3(Random.value, Random.value, Random.value);
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            
            rigidbody.AddTorque(new Vector3(Random.value, Random.value, Random.value) * _data.TorqueModifier,
                ForceMode.Impulse);
            rigidbody.AddForce(new Vector3(Random.value, 0, Random.value) * _data.ForceModifier, ForceMode.Impulse);
        }
    }
}