using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float energy = 100f;
    public WeaponSO equippedWeapon;
    public ArmorSO equippedArmor;
    public Inventory inventory = new Inventory(3);
    public ArmorInventory armorInventory = new ArmorInventory(3);
    public WeaponInventory weaponInventory = new WeaponInventory(3);
    public float baseSpeed = 5f;
    public SpecialPower[] specialPowers;
    public WeaponUniquePower weaponUniquePower;

    public float energyRechargeRate = 10f;

    void Start()
    {
        currentHealth = maxHealth;
        weaponUniquePower = equippedWeapon.weaponUniquePower;
    }

    void Update()
    {
        // Recharge energy
        energy += energyRechargeRate * Time.deltaTime;
        energy = Mathf.Clamp(energy, 0f, 100f);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle death here
        Debug.Log("Character is dead");
    }

    public void UseSpecialPower(int powerIndex)
    {
        if (powerIndex < 0 || powerIndex >= specialPowers.Length)
        {
            Debug.LogError("Invalid special power index!");
            return;
        }

        if (energy < specialPowers[powerIndex].energyCost)
        {
            Debug.Log("Not enough energy to use special power!");
            return;
        }

        energy -= specialPowers[powerIndex].energyCost;
        specialPowers[powerIndex].UseSpecialPower(this);
    }

    public void UseWeaponUniquePower(int powerIndex)
    {
        weaponUniquePower.UseUniqueWeaponPower(this);
    }

    public void EquipWeapon(WeaponSO weapon)
    {
        equippedWeapon = weapon;
    }

    public void EquipArmor(ArmorSO armor)
    {
        equippedArmor = armor;
    }
}
