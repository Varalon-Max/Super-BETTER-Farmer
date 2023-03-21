using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpawnHandler
{
    public class TextHandler: MonoBehaviour
    {
        [SerializeField] private List<GameObject> _spawnCounters;
        private TextMeshProUGUI _currentTextPlaceholder;
        public void IncreaseNumber(int numberOfTier, int newNumber)
        {

            numberOfTier += 5;
            _currentTextPlaceholder = _spawnCounters[numberOfTier].GetComponent<TextMeshProUGUI>();
            _currentTextPlaceholder.text = newNumber.ToString();
        }
    }
}