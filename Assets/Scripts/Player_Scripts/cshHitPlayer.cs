using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshHitPlayer : LivingEntity
{
    public Collider enemyBody;
    private cshHitMonster hitMonster;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("√Êµπ");
        if (other.gameObject.tag == "Monster")
        {
            Debug.Log("∏ÛΩ∫≈Õ");
            hitMonster = other.GetComponent<cshHitMonster>();
            hitMonster.OnTakeDamage(10f);
        }
    }
    private void OnEnable()
    {
        hp = maxHp;
    }

    public override void OnTakeDamage(float _damage)
    {
        hp -= _damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollider()
    {
        Debug.Log("ƒ—¡¸");
        enemyBody.enabled = true;
    }

    private void OffCollider()
    {
        Debug.Log("≤®¡¸");
        enemyBody.enabled = false;
    }
}
