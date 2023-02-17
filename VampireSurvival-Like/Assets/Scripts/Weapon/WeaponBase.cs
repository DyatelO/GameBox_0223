using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponData _weaponData; // { get; set; }
    //[SerializeField] private WeaponStats weaponStats;
    public WeaponStats _weaponStats;

    //private float _timeToAttack = 1f;
    private float _timer;

    //public float TimeToAttack { get => _timeToAttack; }
    public WeaponStats WeaponStats { get => _weaponStats; }

    public void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            Attack();
            //_timer = _timeToAttack;
            _timer = _weaponStats.TimeToAttack;
        }
    }

    public virtual void SetData(WeaponData weaponData)
    {
        _weaponData = weaponData;
        //_timeToAttack = _weaponData.WeaponStats.TimeToAttack;

        _weaponStats = new WeaponStats(weaponData.WeaponStats.Damage, weaponData.WeaponStats.TimeToAttack);
    }

    //Возможно нужен интерфейс.
    public abstract void Attack();

    public void Upgrade(UpgradeData upgradeData)
    {
        _weaponStats.Sum(upgradeData.weaponUpgradeStats);
    }
}
