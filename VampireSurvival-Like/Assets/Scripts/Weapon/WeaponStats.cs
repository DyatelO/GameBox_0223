using System;
using UnityEngine;

[Serializable]
public class WeaponStats
{
    [SerializeField] private int damage;
    [SerializeField] private float timetoAttack;
    public int numberOfAttack;

    public WeaponStats(int damage, float timetoAttack, int numberOfAttack)
    {
        this.damage = damage;
        this.timetoAttack = timetoAttack;
        this.numberOfAttack = numberOfAttack;
    }

    public int Damage { get => damage;  }
    public float TimeToAttack { get => timetoAttack; }

    internal void Sum(WeaponStats weaponUpgradeStats)
    {
        this.damage += weaponUpgradeStats.damage;
        this.timetoAttack += weaponUpgradeStats.timetoAttack;
        this.numberOfAttack += weaponUpgradeStats.numberOfAttack;
    }
}
