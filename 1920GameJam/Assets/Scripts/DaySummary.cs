using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam1920.Assets.Scripts
{
    public class DaySummary : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshPro _alliesText;
        [SerializeField] private TMPro.TextMeshPro _enemiesText;
        [SerializeField] private TMPro.TextMeshPro _territoryText;

        private ScoreManager _scoreManager;

        private void Start()
        {
            _scoreManager = FindObjectOfType<ScoreManager>();
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _alliesText.text = _scoreManager.alliesLoss.ToString();
            _enemiesText.text = _scoreManager.enemiesLoss.ToString();
            _territoryText.text = _scoreManager.territory.ToString();

        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
