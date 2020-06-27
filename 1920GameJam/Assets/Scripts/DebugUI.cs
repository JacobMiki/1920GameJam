using System.Collections;
using System.Collections.Generic;
using GameJam1920.Assets.Scripts.Messages;
using UnityEngine;

namespace GameJam1920.Assets.Scripts
{
    public class DebugUI : MonoBehaviour
    {
        [SerializeField] private MessageSpawner _messageSpawner;

        public void SpawnMessage(bool correct)
        {
            _messageSpawner.SpawnMessage(correct);
        }

        public void ClearMessages()
        {
            var children = new List<GameObject>();
            foreach (Transform child in _messageSpawner.transform)
            {
                children.Add(child.gameObject);
            }
            children.ForEach(child => Destroy(child));

        }
    }
}