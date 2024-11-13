using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handle damaging entities
public enum DamageType { Physical, Holy };
public interface IDamageable
{
    void TakeDamage(float damage, DamageType type);
}