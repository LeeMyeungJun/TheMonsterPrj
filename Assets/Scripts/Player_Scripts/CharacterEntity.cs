using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEntity : IDamageable
{
    protected float hp = 10.0f;
    protected float damage = 10.0f;

    public virtual void OnTakeDamage(float _damage) { }
}
