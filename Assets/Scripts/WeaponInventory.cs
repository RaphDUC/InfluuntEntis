using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    public int capacity;
    public List<Weapon> Weapons = new List<Weapon>(3);

    public WeaponInventory(int capacity)
    {
        this.capacity = capacity;
    }
    public bool AddItem(Weapon Weapon)
    {
        if (Weapons.Count >= capacity)
        {
            Debug.Log("Inventory is full!");
            return false;
        }

        Weapons.Add(Weapon);
        Debug.Log("Item added to inventory: " + Weapon.name);
        return true;
    }
}
