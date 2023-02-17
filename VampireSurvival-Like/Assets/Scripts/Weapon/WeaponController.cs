using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform weaponObjectContainer;
    [SerializeField] private WeaponData startWeapon;

    private void Start()
    {
        AddWeapon(startWeapon);
    }

    public void AddWeapon(WeaponData weaponData)
    {
        GameObject weaponGameObject = Instantiate(weaponData.WeaponBasePrefab, weaponObjectContainer);

        weaponGameObject.GetComponent<WeaponBase>().SetData(weaponData);
    }
}
