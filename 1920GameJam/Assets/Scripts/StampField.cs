using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam1920.Assets.Scripts.Messages
{
    public class StampField : MonoBehaviour
    {
        [SerializeField] private Sprite _approved;
        [SerializeField] private Sprite _rejected;

        [SerializeField] private Transform _stampSign;

        public AudioClip correct;
        public AudioClip inCorrect;

        private ScoreManager scoreManager;
        private FeedbackSpawner feedbackSpawner;
        private AudioSource audioSource;
        private bool _isSigned = false;

        private void Start()
        {
            scoreManager = FindObjectOfType<ScoreManager>();
            feedbackSpawner = FindObjectOfType<FeedbackSpawner>();
            audioSource = GetComponentInParent<AudioSource>();
        }

        public bool Sign(Vector2 stampPosition, bool isApproved)
        {
            if (_isSigned) return false;

            var sprite = isApproved ? _approved : _rejected;
            _stampSign.position = new Vector3(stampPosition.x,stampPosition.y-.5f, transform.position.z);
            _stampSign.GetComponent<SpriteRenderer>().sprite = sprite;
            _isSigned = true;

            var message = GetComponentInParent<Message>();
            scoreManager.UpdateScore(message.GetIsCorrect(), isApproved);
            if (message.GetIsCorrect() != isApproved)
            {
                feedbackSpawner.SpawnFeedback(message.GetErrorCategory());
                audioSource.PlayOneShot(inCorrect);
            }
            else
            {
                audioSource.PlayOneShot(correct);
            }
            message.TriggerLeave();
            return true;
        }
    }
}
