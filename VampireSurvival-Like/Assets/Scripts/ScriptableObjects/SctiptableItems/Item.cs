using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private int armor;

    public string Name { get => name; set => name = value; }
    public int Armor { get => armor; set => armor = value; }

    public void Equip(Character character)
    {
        character.Armor += armor;
    }
    public void UnEquip(Character character)
    {
        character.Armor -= Armor;
    }
}
