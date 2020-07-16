using System.Collections;
using System.Collections.Generic;
using GameJam1920.Assets.Scripts.Contracts;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameJam1920.Assets.Scripts
{
    public class ItemInteractions : MonoBehaviour
    {
        [SerializeField] private LayerMask _draggableLayers;
        [SerializeField] private LayerMask _interactableLayers;

        private Vector2 _mousePositionInWorldSpace;
        private IDraggable _heldItem;
        private float _topItemZIndex = 0;

        public void ResetTopZIndex()
        {
            _topItemZIndex = 0;
        }

        public void SetMousePosition(InputAction.CallbackContext context)
        {
            _mousePositionInWorldSpace = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        }

        public void OnHold(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                var item = Physics2D.OverlapPoint(_mousePositionInWorldSpace, _draggableLayers);
                if (item)
                {
                    var draggable = item.GetComponent<IDraggable>();
                    if (draggable != null)
                    {
                        _topItemZIndex -= 0.01f;
                        item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y, _topItemZIndex);
                        _heldItem = draggable;
                        _heldItem.DragStart(_mousePositionInWorldSpace);
                    }
                }
            }
            else if (context.canceled && _heldItem != null)
            {
                _heldItem.DragEnd(_mousePositionInWorldSpace);
                _heldItem = null;
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                var item = Physics2D.OverlapPoint(_mousePositionInWorldSpace, _interactableLayers);
                if (item)
                {
                    var interactrable = item.GetComponent<IInteractable>();
                    if (interactrable != null)
                    {
                        interactrable.Interact(_mousePositionInWorldSpace);
                    }
                }
            }
        }

        private void FixedUpdate()
        {
            if (_heldItem != null)
            {
                _heldItem.OnDrag(_mousePositionInWorldSpace);
            }
        }
    }
}
