using System;
using System.Collections;
using System.Collections.Generic;
using GameJam1920.Assets.Scripts.Data;
using UnityEngine;

namespace GameJam1920.Assets.Scripts
{
    public class ScoreManager : MonoBehaviour
    {
        [HideInInspector] public int territory = 0;
        [HideInInspector] public int enemiesLoss = 0;
        [HideInInspector] public int alliesLoss = 0;

        [HideInInspector] public int totalTerritory = 0;
        [HideInInspector] public int totalEnemiesLoss = 0;
        [HideInInspector] public int totalAlliesLoss = 0;

        private Day _day;

        public void OnNewDay(Day day)
        {
            _day = day;
            UpdateNewDayScore();
        }

        public void UpdateScore(bool isCorrect, bool isApproved)
        {
            Debug.Log("Updating");
            if(isCorrect==isApproved) // poprawna decyzja
            {
                territory += _day.RightAnswerTeritoryChange;
                totalTerritory += _day.RightAnswerTeritoryChange;
                enemiesLoss += _day.RightAnswerPeopleChange;
                totalEnemiesLoss += _day.RightAnswerPeopleChange;
            }
            else
            {
                territory += _day.WrongAnswerTeritoryChange;
                totalTerritory += _day.WrongAnswerTeritoryChange;
                alliesLoss += _day.WrongAnswerPeopleChange;
                totalEnemiesLoss += _day.WrongAnswerPeopleChange;
            }
        }

        private void UpdateNewDayScore()
        {
            territory = _day.TeritoryChange;
            totalTerritory += _day.TeritoryChange;
            enemiesLoss = _day.EnemyPeopleLoss;
            totalEnemiesLoss += _day.EnemyPeopleLoss;
            alliesLoss = _day.FriendlyPeopleLoss;
            totalEnemiesLoss += _day.FriendlyPeopleLoss;
        }
    }
}
