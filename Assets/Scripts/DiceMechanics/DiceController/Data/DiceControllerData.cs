using System;
using UnityEngine;

namespace DiceMechanics.DiceController.Data
{
    [Serializable]
    public class DiceControllerData
    {
        [field: SerializeField] public Vector3 SpawnCoordinates { get; private set; }
        [field: SerializeField] public float ForceModifier { get; private set; }
        [field: SerializeField] public float TorqueModifier { get; private set; }
    }
}