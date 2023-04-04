using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpawnHandler
{
    public class TextHandler: MonoBehaviour
    {
        [SerializeField] private List<TextMeshProUGUI> _spawnCounters;
        private TextMeshProUGUI _currentTextPlaceholder;
        public void IncreaseNumber(int numberOfTier)
        {
            _currentTextPlaceholder = _spawnCounters[numberOfTier - 1];
            int newNumber = Int32.Parse(_currentTextPlaceholder.text);
            _currentTextPlaceholder.text = (newNumber+1).ToString();
        }
    }
}