using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform weaponObjectContainer;
    [SerializeField] private WeaponData startWeapon;

    private List<WeaponBase> weapons;


    private void Awake()
    {
        weapons = new List<WeaponBase>();
    }
    private void Start()
    {
        AddWeapon(startWeapon);
    }

    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.WeaponBasePrefab, weaponObjectContainer);

        WeaponBase weaponBase = weaponGameObject.GetComponent<WeaponBase>();

        weaponBase.SetData(weaponData);
        weapons.Add(weaponBase);

        weaponGameObject.GetComponent<WeaponBase>().SetData(weaponData);

        Level level = GetComponent<Level>();
        if(level != null)
        {
            level.AddUpgradesIntoTheListOfAvailableUpgrades(weaponData.UpgradesList);
        }
    }

    internal void UpgradeWeapon(UpgradeData upgradeData)
    {
        WeaponBase weaponToUpgrade = weapons.Find(weaponBase => weaponBase._weaponData == upgradeData.weaponData);
        weaponToUpgrade.Upgrade(upgradeData);
    }
}
