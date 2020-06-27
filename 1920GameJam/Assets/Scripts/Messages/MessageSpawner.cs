using GameJam1920.Assets.Scripts.Data;
using GameJam1920.Assets.Scripts.Messages.MessageSources;
using UnityEngine;

namespace GameJam1920.Assets.Scripts.Messages
{
    class MessageSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _messagePrefab;

        private IMessageSource _messageSource;

        private void Start()
        {
            _messageSource = GetComponent<IMessageSource>();
        }

        private void SetupSource(MessageData messageData)
        {
            _messageSource.SetupSource(messageData);
        }

        public void OnNewDay(Day day)
        {
            SetupSource(day.MessageData);
        }

        public void SpawnMessage(bool correct)
        {
            Debug.Log("Spawning message");
            var content = _messageSource.GetMessage(correct);
            if (content != null)
            {
                var messageObject = Instantiate(_messagePrefab, transform);
                var message = messageObject.GetComponent<Message>();
                if (message == null)
                {
                    Debug.LogError("Message game object does not contain Message script");
                }
                else
                {
                    message.SetContent(content);
                }
            } else
            {
                Debug.LogError($"No message content available for {correct}");
            }
        }
    }
}
