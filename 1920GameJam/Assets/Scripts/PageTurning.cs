using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PageTurning : MonoBehaviour
{
    [SerializeField] private Sprite[] _pages;
    private int _currentPage = 0;
    public SpriteRenderer _renderer;
    public Collider2D _myCollider;
    private Vector2 mousePosition;
    private Vector2 mousePositionInWorldSpace;

    private void Start()
    {
        //_renderer = GetComponentInParent<SpriteRenderer>();
        //_myCollider = GetComponent<Collider2D>();
    }

    public void SetMousePosiotion(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
        mousePositionInWorldSpace = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    public void OnMouseDown(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            return;
        }
        Collider2D movableItem = Physics2D.OverlapPoint(mousePositionInWorldSpace, LayerMask.GetMask("Movable Items"));
        if (movableItem.GetComponent<PageTurning>())
        {
            movableItem.GetComponent<PageTurning>().TurnPage();
        }
    }

    private void TurnPage()
    {
        _currentPage++;
        _currentPage %= _pages.Length;

        GetComponent<SpriteRenderer>().sprite = _pages[_currentPage];
    }
}
