using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : WeaponBase
{
    [SerializeField] private GameObject leftWhipSide;
    [SerializeField] private GameObject rightWhipSide;

    private PlayerMove _playerMove;

    private Vector2 attackSize = new Vector2(1f, 0.25f);

    private void Awake()
    {
        _playerMove = GetComponentInParent<PlayerMove>();
            //FindObjectOfType<PlayerMove>();
    }

    public override void Attack()
    {
        if (_playerMove.LastHorizontalVectorLength > 0)
        {
            rightWhipSide.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipSide.transform.position, attackSize, 0f);
            ApplyDamage(colliders);
        }
        else
        {
            leftWhipSide.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipSide.transform.position, attackSize, 0f);
            ApplyDamage(colliders);
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        foreach (var item in colliders)
        {
            //Debug.Log(item.gameObject.name);
            //Enemy enemy = item.GetComponent<Enemy>();
            IDamageable eneny = item.GetComponent<IDamageable>();
            if(eneny != null)
            {
                eneny.TakeDamage(WeaponStats.Damage);
                //item.GetComponent<Enemy>().TakeDamage(whipDamage);
            }
        }
    }

}
