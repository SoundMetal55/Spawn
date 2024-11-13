using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// manages a character's incoming damage and healing. governs resistances as well
public class HealthComponent : MonoBehaviour, IDamageable
{

    //[RequireComponent(typeof(DamageComponent))]
    [SerializeField]
    private float physicalResistance;
    [SerializeField]
    private float holyResistance;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float health;

    [Header("Shield Settings")]
    public int shield = 0;
    public int maxShield = 0;

    private bool isAlive;

    public Slider healthBar;

    void Start()
    {
        
        SetStats();
    }

    void SetStats()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
        isAlive = true;
    }

    public void TakeDamage(float damage, DamageType type = DamageType.Physical)
    {
        health -= CalculateDamage(damage, type);
        if (health <= 0)
        {
            health = 0;
            isAlive = false;
        }
        healthBar.value = health;
    }

    public float CalculateDamage(float damage, DamageType type)
    {

        switch(type)
        {
            case DamageType.Physical:
                break;
            case DamageType.Holy:
                break;
        }
        return damage;
    }
}

