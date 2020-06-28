using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameJam1920.Assets.Scripts.Messages;
using UnityEngine;

namespace GameJam1920.Assets.Scripts
{
    [Serializable]
    public class FeedbackForType
    {
        public ErrorCategory errorCategory;
        public Sprite errorSprite;
    }

    public class FeedbackSpawner : MonoBehaviour
    {
        [SerializeField] private FeedbackForType[] _feedbackList;
        [SerializeField] private GameObject _feedbackPrefab;

        public void SpawnFeedback(ErrorCategory cat)
        {
            var type = _feedbackList.FirstOrDefault(t => t.errorCategory == cat);
            if (type == null)
            {
                Debug.LogError($"Missing feedback for type {cat}");
                return;
            }

            var instance = Instantiate(_feedbackPrefab, transform);

            var sr = instance.GetComponentInChildren<SpriteRenderer>();
            if (sr != null)
            {
                sr.sprite = type.errorSprite;
            }
        }

        public void Clear()
        {
            var children = new List<GameObject>();
            foreach (Transform child in transform)
            {
                children.Add(child.gameObject);
            }
            children.ForEach(child => Destroy(child));
        }
    }
}
