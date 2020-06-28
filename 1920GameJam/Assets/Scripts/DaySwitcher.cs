using System;
using System.Collections;
using System.Collections.Generic;
using GameJam1920.Assets.Scripts.Data;
using GameJam1920.Assets.Scripts.Messages;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace GameJam1920.Assets.Scripts
{
    public enum DaySwitcherState
    {
        PRE_DAY,
        DAY,
        END_DAY
    }

    [System.Serializable]
    public class NewDayEvent : UnityEvent<Day>
    {
    }

    [System.Serializable]
    public class PreDayEvent : UnityEvent<Day>
    {
    }

    public class DaySwitcher : MonoBehaviour
    {
        [SerializeField] private DaySummary _daySummary;
        [SerializeField] private Day[] days;
        [SerializeField] private TMPro.TextMeshPro calendarText;
        [SerializeField] private Transform aidsContainer;

        [SerializeField] private PreDayEvent _preDayEvent;
        [SerializeField] private NewDayEvent _newDayEvent;
        [SerializeField] private UnityEvent _dayEndEvent;

        private int currentDay = -1;
        public DaySwitcherState state { get; private set; } = DaySwitcherState.END_DAY;

        private void Start()
        {
            if (_preDayEvent == null)
            {
                _preDayEvent = new PreDayEvent();
            }

            if (_newDayEvent == null)
            {
                _newDayEvent = new NewDayEvent();
            }

            if (_dayEndEvent == null)
            {
                _dayEndEvent = new UnityEvent();
            }

            PreDay();
        }

        private void SetCalendarDate()
        {
            if (calendarText != null)
            {
                calendarText.text = days[currentDay].Date;
            }
        }

        private void SpawnAids()
        {
            var children = new List<GameObject>();
            foreach (Transform child in aidsContainer)
            {
                children.Add(child.gameObject);
            }
            children.ForEach(child => Destroy(child));

            var day = days[currentDay];

            foreach (var aid in day.aidPrefabs)
            {
                Instantiate(aid, aidsContainer, true);
            }

        }

        public void PreDay()
        {
            if (state != DaySwitcherState.END_DAY)
            {
                return;
            }
            state = DaySwitcherState.PRE_DAY;

            currentDay++;
            if (currentDay >= days.Length)
            {
                SceneManager.LoadScene(0);
                return;
            }
            SetCalendarDate();

            _preDayEvent.Invoke(days[currentDay]);
        }

        public void EndDay()
        {
            if (state != DaySwitcherState.DAY)
            {
                return;
            }
            state = DaySwitcherState.END_DAY;

            _dayEndEvent.Invoke();
        }

        public void NextDay()
        {
            if (state != DaySwitcherState.PRE_DAY)
            {
                return;
            }
            state = DaySwitcherState.DAY;

            SpawnAids();
            _newDayEvent.Invoke(days[currentDay]);
        }
    }
}
