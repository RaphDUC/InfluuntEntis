using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory
{
    public int capacity;
    public List<Item> items = new List<Item>();

    public Inventory(int capacity)
    {
        this.capacity = capacity;
    }

    public bool AddItem(Item item)
    {
        if (items.Count >= capacity)
        {
            Debug.Log("Inventory is full!");
            return false;
        }

        items.Add(item);
        Debug.Log("Item added to inventory: " + item.name);
        return true;
    }

    public bool RemoveItem(Item item)
    {
        if (!items.Contains(item))
        {
            Debug.Log("Item not found in inventory!");
            return false;
        }

        items.Remove(item);
        Debug.Log("Item removed from inventory: " + item.name);
        return true;
    }

    public void Clear()
    {
        items.Clear();
        Debug.Log("Inventory cleared!");
    }
}
