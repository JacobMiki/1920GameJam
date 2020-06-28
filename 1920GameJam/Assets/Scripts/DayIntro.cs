using System.Collections;
using System.Collections.Generic;
using GameJam1920.Assets.Scripts.Data;
using UnityEngine;

namespace GameJam1920.Assets.Scripts
{
    public class DayIntro : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshPro _titleText;
        [SerializeField] private TMPro.TextMeshPro _descriptionText;

        private void Start()
        {
            Hide();
        }

        public void Show(Day day)
        {
            gameObject.SetActive(true);
            _titleText.text = day.Title;
            _descriptionText.text = day.Description;

        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
