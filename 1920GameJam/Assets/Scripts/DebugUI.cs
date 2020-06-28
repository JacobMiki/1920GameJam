using System.Collections;
using System.Collections.Generic;
using GameJam1920.Assets.Scripts.Messages;
using UnityEngine;

namespace GameJam1920.Assets.Scripts
{
    public class DebugUI : MonoBehaviour
    {
        [SerializeField] private MessageSpawner _messageSpawner;
        [SerializeField] private DaySwitcher _daySwitcher;

        public void SpawnMessage(bool correct)
        {
            var children = new List<GameObject>();
            foreach (Transform child in _messageSpawner.transform)
            {
                children.Add(child.gameObject);
            }
            children.ForEach(child => Destroy(child));
            if (!_messageSpawner.TrySpawnMessage())
            {
                EndDay();
            }
        }

        public void EndDay()
        {
            _daySwitcher.EndDay();

        }
    }
}
