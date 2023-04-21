using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public WeaponSO weapon;

    

    public override void AddToInventory(Character character)
    {
        // Add the weapon to the player's weapon inventory
        character.weaponInventory.AddItem(this);
        Debug.Log("Character " + character + " received the weapon "+ this.itemName);

    }
}
