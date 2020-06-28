using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameJam1920.Assets.Scripts.Data;
using GameJam1920.Assets.Scripts.Messages.MessageSources;
using UnityEngine;

namespace GameJam1920.Assets.Scripts.Messages
{
    class MessageSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _messagePrefab;
        [SerializeField] private float _initialSpawnDelay;

        private IMessageSource _messageSource;
        private Queue<bool> _messageQueue;

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
            var messageList = new List<bool>();
            for (var i = 0; i < day.CorrectMessages; i++)
            {
                messageList.Add(true);
            }
            for (var i = 0; i < day.IncorrectMessages; i++)
            {
                messageList.Add(false);
            }
            _messageQueue = new Queue<bool>(messageList.OrderBy(_ => Random.value));

            StartCoroutine(SpawnInitialMessage());
        }

        public bool TrySpawnMessage()
        {
            if (_messageQueue.Count == 0)
            {
                return false;
            }

            var isCorrect = _messageQueue.Dequeue();
            SpawnMessage(isCorrect);

            return true;
        }

        public void SpawnMessage(bool correct)
        {
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

        private IEnumerator SpawnInitialMessage()
        {
            yield return new WaitForSeconds(_initialSpawnDelay);
            TrySpawnMessage();
        }
    }
}
