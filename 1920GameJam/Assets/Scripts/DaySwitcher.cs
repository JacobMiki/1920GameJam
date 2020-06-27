using System;
using System.Collections;
using System.Collections.Generic;
using GameJam1920.Assets.Scripts.Data;
using GameJam1920.Assets.Scripts.Messages;
using UnityEngine;
using UnityEngine.Events;

namespace GameJam1920.Assets.Scripts
{
    [System.Serializable]
    public class NewDayEvent : UnityEvent<Day>
    {
    }

    public class DaySwitcher : MonoBehaviour
    {
        [SerializeField] private DaySummary _daySummary;
        [SerializeField] private Day[] days;
        [SerializeField] private TMPro.TextMeshPro calendarText;

        [SerializeField] private NewDayEvent _newDayEvent;

        private int currentDay = 0;

        private void Start()
        {
            SetCalendarDate();

            if (_newDayEvent == null)
            {
                _newDayEvent = new NewDayEvent();
            }

            _newDayEvent.Invoke(days[currentDay]);
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
            _newDayEvent.Invoke(days[currentDay]);
        }
    }
}
