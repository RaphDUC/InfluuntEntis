using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;
using static UnityEditor.Progress;

public class ArmorInventory : MonoBehaviour
{
    public int capacity;
    public List<Armor> armors = new List<Armor>(3);

    public ArmorInventory(int capacity)
    {
        this.capacity = capacity;
    }
    public bool AddItem(Armor armor)
    {
        if (armors.Count >= capacity)
        {
            Debug.Log("Inventory is full!");
            return false;
        }

        armors.Add(armor);
        Debug.Log("Item added to inventory: " + armor.name);
        return true;
    }
}
