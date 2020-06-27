using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam1920.Assets.Scripts.Data;
using UnityEngine;

namespace GameJam1920.Assets.Scripts.Messages.MessageSources
{
    public class HardcodedMessageSource : MonoBehaviour, IMessageSource
    {
        [SerializeField] private HardcodedMessages _messages;
        private List<MessageContent> _discarded = new List<MessageContent>();
        public MessageContent GetMessage(bool correct)
        {
            var message = _messages.Messages.FirstOrDefault(m => m.IsCorrect == correct);

            if (message == null)
            {
                _messages.Messages.AddRange(_discarded);
                _discarded.Clear();
                message = _messages.Messages.FirstOrDefault(m => m.IsCorrect == correct);
                if (message == null)
                {
                    return null;
                }
            }

            _discarded.Add(message);
            _messages.Messages.Remove(message);

            return message;
        }
    }
}
