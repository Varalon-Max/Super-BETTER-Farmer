using System.Collections.Generic;
using Core.InputView;
using DiceMechanics;
using DiceMechanics.DiceController;
using DiceMechanics.DiceController.Data;
using UnityEngine;

namespace Core
{
    public class GameLevelInitializer : MonoBehaviour
    {
        [SerializeField] private List<DiceScript> _dice;
        [SerializeField] private DiceControllerData _diceControllerData;
        
        private DiceController _diceController;
        private IInputView _inputView;

        private void Awake()
        {
            // ProjectUpdater.Instance;
            _inputView = new ExternalDeviceInputView();
            _diceController = new DiceController(_diceControllerData, _dice);
            //_diceController.Initialize();
        }
        
        private void Update()
        {
            if (_inputView.RollDice)
            {
                _diceController.RollDices();
            }
            
            _inputView.ResetOneTimeActions();
        }
    }
}