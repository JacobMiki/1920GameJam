using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam1920.Assets.Scripts
{
    public class DaySwitcher : MonoBehaviour
    {
        [Serializable]
        struct Day
        {
            public string date;
        }

        [SerializeField] private Day[] days;
        [SerializeField] private TMPro.TextMeshPro calendarText;
        private int currentDay = 0;

        private void Start()
        {
            SetCalendarDate();
        }

        private void SetCalendarDate()
        {
            calendarText.text = days[currentDay].date;
        }

        public void NextDay()
        {
            currentDay++;
            if(currentDay>=days.Length)
            {
                Debug.Log("THE END");
                return;
            }
            SetCalendarDate();
        }
    }
}
