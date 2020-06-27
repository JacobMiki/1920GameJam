using System;
using System.Collections;
using System.Collections.Generic;
using GameJam1920.Assets.Scripts.Data;
using UnityEngine;

namespace GameJam1920.Assets.Scripts
{
    public class DaySwitcher : MonoBehaviour
    {
        [SerializeField] private Day[] days;
        [SerializeField] private TMPro.TextMeshPro calendarText;
        private int currentDay = 0;

        private void Start()
        {
            SetCalendarDate();
        }

        private void SetCalendarDate()
        {
            calendarText.text = days[currentDay].Date;
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
