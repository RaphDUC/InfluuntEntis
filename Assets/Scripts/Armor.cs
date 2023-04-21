using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    public ArmorSO armor;

    public override void AddToInventory(Character character)
    {
        // Add the weapon to the player's armor inventory
        character.armorInventory.AddItem(this);
        Debug.Log("Character " + character + " received the armor " + this.itemName);

    }
}

