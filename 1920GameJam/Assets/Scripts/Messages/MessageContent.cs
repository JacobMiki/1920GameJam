using System;
using UnityEngine;

namespace GameJam1920.Assets.Scripts.Messages
{
    [Serializable]
    public class MessageContent
    {
        public string Name;

        public string Date;

        public string Codeword;

        public string CommandingOfficer;

        [TextArea]
        public string Order;

        public bool IsCorrect;

        public string ErrorCategory;
    }
}
