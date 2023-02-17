using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingAxeWeapon : WeaponBase
{
    private PlayerMove _playerMove;

    [SerializeField] private GameObject axePrefab;

    private void Awake()
    {
        _playerMove = FindObjectOfType<PlayerMove>();
    }

    public override void Attack()
    {
        GameObject thrownAxe = Instantiate(axePrefab);
        thrownAxe.transform.position = transform.position;
        //thrownAxe.transform.localEulerAngles = Vector3.forward * -45;
        ThrownAxeProjectile thrownAxeProjectile = axePrefab.GetComponent<ThrownAxeProjectile>();
        thrownAxeProjectile.SetDirection(_playerMove.LastHorizontalVectorLength, Vector2.up.y + 10);
        thrownAxeProjectile.damage = WeaponStats.Damage;
    }
}
