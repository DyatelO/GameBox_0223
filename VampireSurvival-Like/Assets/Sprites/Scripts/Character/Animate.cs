using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    public float ToRight { get; set; }

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        //Отсебятина
        //AnimateViewModel animateViewModel = new AnimateViewModel();
        //animateViewModel.Animator = _animator;
    }

    private void Update()
    {

        if (ToRight == 0)
        {
            return;
        }        
        _animator.SetFloat("Right", ToRight);

        //Можно сделать событием.
        if (ToRight > 0)
        {
            _spriteRenderer.flipX = false;
            //_animator.SetFloat("Right", ToRight);
        }
        if (ToRight < 0)
        {
            _spriteRenderer.flipX = true;
            //_animator.SetFloat("Left", ToRight);
        }
    }
}
