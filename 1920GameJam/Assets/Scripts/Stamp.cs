using GameJam1920.Assets.Scripts.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameJam1920.Assets.Scripts
{
    public class Stamp : MonoBehaviour
    {
        public bool approved;

        private Vector2 mousePositionInWorldSpace;
        private float duration=1;
        private float durationTime;
        private Vector3 startPosition;
        private Vector3 endPosition;

        private bool isMovingDown = false;
        private bool isMoving = false;

        private void Start()
        {
            startPosition = transform.position;
            endPosition = transform.position + Vector3.down*.5f;
        }

        public void SetMousePosiotion(InputAction.CallbackContext context)
        {
            mousePositionInWorldSpace = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        }

        public void OnMouseDown(InputAction.CallbackContext context)
        {
            if (!context.started) return;

            Collider2D stamp = Physics2D.OverlapPoint(mousePositionInWorldSpace, LayerMask.GetMask("Stamp"));
            if (!stamp) return;

            if (stamp.GetComponent<Stamp>().approved) Debug.Log("Stamp Clicked: Approved");
            else Debug.Log("Stamp Clicked: Rejected");

            Collider2D stampfield = Physics2D.OverlapPoint(mousePositionInWorldSpace, LayerMask.GetMask("Stamp Field"));
            if (!stampfield) return;
            if(!stampfield.GetComponentInParent<StampField>().Sign(mousePositionInWorldSpace, stamp.GetComponent<Stamp>().approved))return;
            stamp.GetComponent<Stamp>().isMovingDown = true;
            stamp.GetComponent<Stamp>().isMoving = true;
            stamp.GetComponent<AudioSource>().Play();
        }

        void Update()
        {
            if (!isMoving) return;

            if (Vector3.Distance(transform.position,endPosition)>0.01f &&isMovingDown)
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
    }
}
