using GameJam1920.Assets.Scripts.Contracts;
using GameJam1920.Assets.Scripts.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameJam1920.Assets.Scripts
{
    public class Stamp : MonoBehaviour, IInteractable
    {
        [SerializeField] private BoxCollider2D _shadowBox;

        public bool approved;

        private float duration = 1;
        private float durationTime;
        private Vector3 startPosition;
        private Vector3 endPosition;

        private bool isMovingDown = false;
        private bool isMoving = false;

        private void Start()
        {
            startPosition = transform.position;
            endPosition = transform.position + Vector3.down * .5f;
        }

        void Update()
        {
            if (!isMoving) return;

            if (Vector3.Distance(transform.position,endPosition) > 0.01f &&isMovingDown)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPosition, Time.deltaTime*5); 
            }
            else if (Vector3.Distance(transform.position, startPosition) > 0.01f)
            {
                isMovingDown = false;
                transform.position = Vector3.MoveTowards(transform.position, startPosition, Time.deltaTime * 4);
            }
            else
            {
                isMoving = false;
            }
        }

        public void Interact(Vector2 mousePositionInWorldSpace)
        {
            var stampfield = Physics2D.OverlapBox((Vector2)_shadowBox.transform.position + _shadowBox.offset, _shadowBox.size, 0f, LayerMask.GetMask("Stamp Field"));
            if (!stampfield || !stampfield.GetComponent<StampField>().Sign((Vector2)_shadowBox.transform.position + _shadowBox.offset, approved))
            {
                return;
            }

            isMovingDown = true;
            isMoving = true;
            GetComponent<AudioSource>().Play();
        }
    }
}
