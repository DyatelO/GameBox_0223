using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private WeaponStats weaponStats;
    [SerializeField] private GameObject weaponBasePrefab;
    [SerializeField] private List<UpgradeData> upgradesList;


    public string Name { get => name;}
    public WeaponStats WeaponStats { get => weaponStats; }
    public GameObject WeaponBasePrefab { get => weaponBasePrefab;  }
    public List<UpgradeData> UpgradesList { get => upgradesList; }
}
