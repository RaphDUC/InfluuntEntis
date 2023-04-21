using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUniquePower : ScriptableObject
{
    public string weaponPowerName;

    public virtual void UseUniqueWeaponPower(Character user)
    {
        // Default behavior
        Debug.Log(weaponPowerName + " was used by " + user.name);
    }
}