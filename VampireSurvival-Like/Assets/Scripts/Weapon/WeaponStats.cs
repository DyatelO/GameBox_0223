using System;
using UnityEngine;

[Serializable]
public class WeaponStats
{
    [SerializeField] private int damage;
    [SerializeField] private float timetoAttack;

    public WeaponStats(int damage, float timetoAttack)
    {
        this.damage = damage;
        this.timetoAttack = timetoAttack;
    }

    public int Damage { get => damage;  }
    public float TimeToAttack { get => timetoAttack; }
}
