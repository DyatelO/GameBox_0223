using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    private GameObject targetGameobject;
    [SerializeField] private float speed = 3.5f;

    private Rigidbody2D _rigidbody2d;

    [SerializeField] private float hp = 100;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PlayerMove>().transform;

        targetGameobject = target.gameObject;
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        _rigidbody2d.velocity = direction * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject == targetGameobject)
        {
            Attack();

        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if(hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void Attack()
    {
        //Debug.Log("Attack!");
    }

    
}
