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

        private bool _isSigned = false;

        public void Sign(Vector2 stampPosition, bool approved)
        {
            if (_isSigned) return;

            var sprite = approved ? _approved : _rejected;
            _stampSign.position = new Vector3(stampPosition.x,stampPosition.y, transform.position.z);
            _stampSign.GetComponent<SpriteRenderer>().sprite = sprite;
            _isSigned = true;
        }
    }
}
