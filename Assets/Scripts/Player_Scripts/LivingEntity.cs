using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    protected float hp = 10.0f;
    protected float maxHp = 10.0f;

    public virtual void OnTakeDamage(float _damage) { }
}
