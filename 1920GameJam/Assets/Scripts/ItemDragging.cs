using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameJam1920.Assets.Scripts
{
    public class ItemDragging : MonoBehaviour
    {
        private Vector2 mousePosition;
        private Vector2 mousePositionInWorldSpace;
        private Vector2 heldItemOffset;
        private Vector3 heldItemPreviousPosition;
        private Transform heldItem;
        private float topItemZIndex = 0;

        private Vector2 idleShadowOffset=new Vector2(0.02f, 0.02f);
        public Vector2 draggedShadowOffset;

        public void SetMousePosiotion(InputAction.CallbackContext context)
        {
            mousePosition = context.ReadValue<Vector2>();
            mousePositionInWorldSpace = Camera.main.ScreenToWorldPoint(mousePosition);
        }

        public void OnMouseDown(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                if (heldItem)
                {
                    heldItem.GetComponentInChildren<DropShadow>().ShadowOffset = new Vector3(idleShadowOffset.x, idleShadowOffset.y, heldItem.GetComponentInChildren<DropShadow>().ShadowOffset.z);
                    if(CheckIfPositionOutOfScreen(heldItem.position))
                    {
                        heldItem.position = heldItemPreviousPosition;
                    }
                }
                heldItem = null;
                return;
            }
            Collider2D movableItem = Physics2D.OverlapPoint(mousePositionInWorldSpace, LayerMask.GetMask("Movable Items"));
            if (movableItem)
            {
                topItemZIndex -= 0.01f;
                heldItem = movableItem.transform;
                heldItemOffset = new Vector2(mousePositionInWorldSpace.x - heldItem.position.x, mousePositionInWorldSpace.y - heldItem.position.y);
                idleShadowOffset = heldItem.GetComponentInChildren<DropShadow>().ShadowOffset;
                heldItemPreviousPosition = heldItem.position;
            }
        }

        private void FixedUpdate()
        {
            if (heldItem)
            {
                heldItem.position = new Vector3(mousePositionInWorldSpace.x - heldItemOffset.x, mousePositionInWorldSpace.y - heldItemOffset.y, topItemZIndex);
                heldItem.GetComponentInChildren<DropShadow>().ShadowOffset = new Vector3(draggedShadowOffset.x, draggedShadowOffset.y, heldItem.GetComponentInChildren<DropShadow>().ShadowOffset.z); ;
            }
        }

        private bool CheckIfPositionOutOfScreen(Vector2 objectPos)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(objectPos);

            if (pos.x < 0.0) return true;
            if (1.0 < pos.x) return true;
            if (pos.y < 0.0) return true;
            if (1.0 < pos.y) return true;

            return false;
        }
    }
}
