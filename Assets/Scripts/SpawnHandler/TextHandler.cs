using System.Collections.Generic;
using TMPro;
using TurnHandler.TwoPlayers;
using UnityEngine;
using UnityEngine.UI;

namespace SpawnHandler
{
    public class TextHandler: MonoBehaviour
    {
        [SerializeField] private List<GameObject> _spawnCounters;
        [SerializeField] private TurnChecker _turnChecker;
        private TextMeshProUGUI _currentTextPlaceholder;
        public void IncreaseNumber(int numberOfTier, int newNumber)
        {
            if (!_turnChecker._isFirstPlayerTurn)
            {
                numberOfTier += 5;
            }
            _currentTextPlaceholder = _spawnCounters[numberOfTier].GetComponent<TextMeshProUGUI>();
            _currentTextPlaceholder.text = newNumber.ToString();
        }
    }
}