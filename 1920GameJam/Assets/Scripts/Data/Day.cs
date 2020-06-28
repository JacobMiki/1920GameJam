using System.Collections;
using System.Collections.Generic;
using GameJam1920.Assets.Scripts.Messages.MessageSources;
using UnityEngine;

namespace GameJam1920.Assets.Scripts.Data
{
    [CreateAssetMenu(fileName = "Day", menuName = "Game Data/Day")]
    public class Day : ScriptableObject
    {
        public string Date;

        [Header("Messages")]
        public int CorrectMessages;
        public int IncorrectMessages;
        public MessageData MessageData;

        [Header("Values")]
        public GameObject[] aidPrefabs;


        [Header("Base scores")]
        public int EnemyPeopleLoss;
        public int FriendlyPeopleLoss;
        public int TeritoryChange;

        [Header("Scores")]
        public int RightAnswerPeopleChange;
        public int RightAnswerTeritoryChange;
        public int WrongAnswerPeopleChange;
        public int WrongAnswerTeritoryChange;

        [Header("Info screen")]
        [TextArea]
        public string Title;
        [TextArea]
        public string Description;

    }
}
