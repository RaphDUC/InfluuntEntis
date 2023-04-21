using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArmorSO", menuName = "Items/Armors", order = 1)]
public class ArmorSO : ScriptableObject
{
    public int damageReduction = 0;
    public float speedModifier = 0f;
    public float weaponDamageModifier = 0f;
    public float weaponSpeedModifier = 0f;
}