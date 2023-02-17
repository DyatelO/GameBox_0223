using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponData _weaponData; // { get; set; }
    [SerializeField] private WeaponStats weaponStats;

    private float _timeToAttack = 1f;
    private float _timer;

    public float TimeToAttack { get => _timeToAttack; }
    public WeaponStats WeaponStats { get => weaponStats; }

    public void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            Attack();
            _timer = _timeToAttack;
        }
    }

    public virtual void SetData(WeaponData weaponData)
    {
        _weaponData = weaponData;
        _timeToAttack = _weaponData.WeaponStats.TimeToAttack;

        weaponStats = new WeaponStats(weaponData.WeaponStats.Damage, weaponData.WeaponStats.TimeToAttack);
    }

    //�������� ����� ���������.
    public abstract void Attack();

}