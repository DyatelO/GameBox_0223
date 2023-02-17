using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingAxeWeapon : WeaponBase
{
    private PlayerMove _playerMove;

    [SerializeField] private GameObject axePrefab;
    [SerializeField] private float spread = 0.5f;


    private void Awake()
    {
        _playerMove = FindObjectOfType<PlayerMove>();
    }

    public override void Attack()
    {

        for (int i = 0; i < _weaponStats.numberOfAttack; i++)
        {
            GameObject thrownAxe = Instantiate(axePrefab);

            Vector3 newAxePosition = transform.position;
            if(_weaponStats.numberOfAttack > 1)
            {

                newAxePosition.y -= (spread * (_weaponStats.numberOfAttack - 1)) / 2;
                newAxePosition.y += i * spread;
            }

            thrownAxe.transform.position = transform.position;

            //thrownAxe.transform.localEulerAngles = Vector3.forward * -45;
            ThrownAxeProjectile thrownAxeProjectile = axePrefab.GetComponent<ThrownAxeProjectile>();
            thrownAxeProjectile.SetDirection(_playerMove.LastHorizontalVectorLength, Vector2.up.y + 10);
            thrownAxeProjectile.damage = _weaponStats.Damage;
        }
    }
}
