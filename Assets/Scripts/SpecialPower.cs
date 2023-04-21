using System;
using System.Collections;
using UnityEngine;

public abstract class SpecialPower : ScriptableObject
{
    public string powerName;
    public float energyCost;

    public virtual void UseSpecialPower(Character user)
    {
        // Default behavior
        Debug.Log(powerName + " was used by " + user.name);
    }
}
   