using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _movementVector;
    private float _speed = 5f;

    private Animate _animate;

    private float lastHorizontalVectorLength;
    private float lastVerticalVectorLength;

    public Vector2 MovementVector { get => _movementVector; }
    public float LastHorizontalVectorLength { get => lastHorizontalVectorLength;  }
    public float LastVerticalVectorLength { get => lastVerticalVectorLength; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _movementVector = new Vector2();
        //AnimateViewModel
        //_animate = new AnimateViewModel().Animator;
        _animate = GetComponent<Animate>();
    }

    private void Start()
    {
        lastHorizontalVectorLength = 1f;
        lastVerticalVectorLength = 1f;
    }

    private void Update()
    {
        _movementVector.x = Input.GetAxisRaw("Horizontal");
        //Debug.Log(_movementVector.x);
        _movementVector.y = Input.GetAxisRaw("Vertical");

        if (_movementVector.x != 0)
        {
            lastHorizontalVectorLength = _movementVector.x;
            //return;
        }        
        if (_movementVector.y != 0)
        {
            lastVerticalVectorLength = _movementVector.y;
            //return;
        }
            _animate.ToRight = _movementVector.x;
        //Debug.Log(_animate.ToRight);


    }

    private void FixedUpdate()
    {
        _movementVector = _movementVector * _speed;
        _rigidbody2D.velocity = _movementVector;
    }
}
