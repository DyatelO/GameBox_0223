using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    [SerializeField] private List<Item> items;

    private Character character;
    [SerializeField] private Item armorTest;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Start()
    {
        EquipItem(armorTest);
    }

    public void EquipItem(Item itemToEquip)
    {
        if(items == null)
        {
            items = new List<Item>();
        }
        items.Add(itemToEquip);
        itemToEquip.Equip(character);
    }    
    public void UnEquipItem(Item itemToUnEquip)
    {

    }
}
