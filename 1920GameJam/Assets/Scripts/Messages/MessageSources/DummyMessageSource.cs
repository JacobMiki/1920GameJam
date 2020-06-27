using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameJam1920.Assets.Scripts.Messages.MessageSources
{
    public class DummyMessageSource : MonoBehaviour, IMessageSource
    {
        public MessageContent GetMessage(bool correct)
        {
            return new MessageContent
            {
                Date = DateTime.Today.ToString(),
                Codeword = Random.Range(11, 99).ToString(),
                CommandingOfficer = "Napoleon Bonaparte",
                Order = correct ? "Prawdziwy rozkaz" : "Fałszywy rozkaz",
                IsCorrect = correct,
                ErrorCategory = correct ? null : "dummy",
            };
        }
    }
}
