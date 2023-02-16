using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 3.5f;

    private Rigidbody2D _rigidbody2d;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PlayerMove>().transform;
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        _rigidbody2d.velocity = direction * speed;
    }
}
