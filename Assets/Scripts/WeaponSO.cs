using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponSO", menuName = "Items/Weapons", order = 1)]

public class WeaponSO : ScriptableObject
{
    public enum WeaponType { Boots, FightingKey, Spear, MagnetiteWeapon };
    public WeaponType weaponType;
    public WeaponUniquePower weaponUniquePower;

    public int damage = 10;
    public float attackSpeed = 1f;
    public float range = 1f;
    public float speedModifier = 0f;
    public float damageModifier = 0f;
}
