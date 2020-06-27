using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam1920.Assets.Scripts.Data
{
    [CreateAssetMenu(fileName = "Day", menuName = "Game Data/Day")]
    public class Day : ScriptableObject
    {
        public string Date;
    }
}
