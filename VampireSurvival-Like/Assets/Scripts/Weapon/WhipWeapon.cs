using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    private float timeToAttack = 0.5f;
    private float timer;
    private int whipDamage = 25;

    [SerializeField] private GameObject leftWhipSide;
    [SerializeField] private GameObject rightWhipSide;

    private PlayerMove _playerMove;

    private Vector2 whipAttackSize = new Vector2(1f, 0.25f);

    private void Awake()
    {
        _playerMove = GetComponentInParent<PlayerMove>();
            //FindObjectOfType<PlayerMove>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Attack();
        }
    }

    private void Attack()
    {
        //throw new NotImplementedException();
        timer = timeToAttack;

        if (_playerMove.LastHorizontalVectorLength > 0)
        {
            rightWhipSide.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipSide.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
        else
        {
            leftWhipSide.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipSide.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        foreach (var item in colliders)
        {
            //Debug.Log(item.gameObject.name);
            Enemy enemy = item.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(whipDamage);
                //item.GetComponent<Enemy>().TakeDamage(whipDamage);
            }
        }
    }
}
