using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Transform target;
    private GameObject targetGameobject;
    private Character targetCharacter;
    [SerializeField] private float speed = 3.5f;

    private Rigidbody2D _rigidbody2d;

    [SerializeField] private float hp = 25;
    [SerializeField] private int damage = 1;
    [SerializeField] private int experience = 1000;

    //public Transform Target { get => target; set => target = value; }
    //public GameObject TargetGameobject { get => targetGameobject; set => targetGameobject = value; }

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        //target = FindObjectOfType<PlayerMove>().transform;


    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        _rigidbody2d.velocity = direction * speed;
    }

    internal void SetTarget(GameObject target)
    {
        targetGameobject = target;
        this.target = target.transform;
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
            targetGameobject.GetComponent<Level>().AddExperience(experience);
            gameObject.SetActive(false);
        }
    }

    private void Attack()
    {
        //Debug.Log("Attack!");
        if(targetCharacter == null)
        {
            //Destroy(gameObject);
            targetCharacter = targetGameobject.GetComponent<Character>();
        }

        targetCharacter.TakeDamage(damage);
    }

    
}
