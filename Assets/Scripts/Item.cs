using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Item : Interactable
{
    public int itemID;
    public string itemName;
    public int amount = 1;

    public override void Interact(Character character)
    {
        base.Interact(character);
        AddToInventory(character);
    }

    public virtual void AddToInventory(Character character)
    {
        // Add the item to the player's inventory
       character.inventory.AddItem(this);
        Debug.Log("Character "+character+ " received an amount of"+amount+" "+itemName);
    }
}
