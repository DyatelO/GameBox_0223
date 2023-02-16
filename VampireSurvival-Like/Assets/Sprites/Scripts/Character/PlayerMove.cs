using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _movementVector;
    private float _speed = 5;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _movementVector = new Vector2();
    }

    private void Update()
    {
        _movementVector.x = Input.GetAxisRaw("Horizontal");
        _movementVector.y = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        _movementVector = _movementVector * _speed;
        _rigidbody2D.velocity = _movementVector;
    }
}
