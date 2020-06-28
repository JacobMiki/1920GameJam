using System;
using UnityEngine;

namespace GameJam1920.Assets.Scripts.Messages
{
    public enum ErrorCategory
    {
        NONE,
        OFFICER,
        DAY,
        CODE,
        DIRECTION,
        TROOP_TYPE,
    }

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

        public ErrorCategory ErrorCategory;
    }
}
