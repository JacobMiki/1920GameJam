using System;
using System.Collections;
using System.Collections.Generic;
using GameJam1920.Assets.Scripts.Messages;
using UnityEngine;

namespace GameJam1920.Assets.Scripts.Data
{
    [CreateAssetMenu(fileName = "Hardcoded Messages", menuName = "Game Data/Hardcoded Messages")]
    public class HardcodedMessages : ScriptableObject
    {
        public List<MessageContent> Messages;
    }
}