using System;

namespace GameJam1920.Assets.Scripts.Messages
{
    [Serializable]
    public class MessageContent
    {
        public string Date;
        public string Codeword;
        public string CommandingOfficer;
        public string Order;
        public bool IsCorrect;
        public string ErrorCategory;
    }
}
