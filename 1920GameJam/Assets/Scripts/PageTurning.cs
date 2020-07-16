using System;
using System.Collections;
using System.Collections.Generic;
using GameJam1920.Assets.Scripts.Contracts;
using UnityEngine;
using UnityEngine.InputSystem;

public class PageTurning : MonoBehaviour, IInteractable
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Sprite[] _pages;
    private int _currentPage = 0;

    private void TurnPage()
    {
        _currentPage++;
        _currentPage %= _pages.Length;

        _renderer.sprite = _pages[_currentPage];
    }

    public void Interact(Vector2 mousePositionInWorldSpace)
    {
        TurnPage();
    }
}
