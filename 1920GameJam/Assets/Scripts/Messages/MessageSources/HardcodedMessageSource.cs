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
        private List<MessageContent> _messages;
        private List<MessageContent> _discarded = new List<MessageContent>();
        public MessageContent GetMessage(bool correct)
        {
            var message = _messages.FirstOrDefault(m => m.IsCorrect == correct);

            if (message == null)
            {
                _messages.AddRange(_discarded);
                _discarded.Clear();
                message = _messages.FirstOrDefault(m => m.IsCorrect == correct);
                if (message == null)
                {
                    return null;
                }
            }

            _discarded.Add(message);
            _messages.Remove(message);

            return message;
        }

        public void SetupSource(MessageData messageData)
        {
            var hardcodedMessages = messageData as HardcodedMessages;
            if (hardcodedMessages == null)
            {
                Debug.LogError("Wrong message data format for this source");
                return;
            }

            _messages = new List<MessageContent>(hardcodedMessages.Messages);
            _messages.OrderBy(message => UnityEngine.Random.value);
        }
    }
}
