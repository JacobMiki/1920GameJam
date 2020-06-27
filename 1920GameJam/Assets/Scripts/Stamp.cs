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
            stampfield.GetComponentInParent<StampField>().Sign(mousePositionInWorldSpace, stamp.GetComponent<Stamp>().approved);
        }


    }
}
