using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class cshHitMonster : LivingEntity
{
    public Collider weaponCollider;
    private cshHitPlayer hitPlayer;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌");
        if (other.gameObject.tag == "Monster")
        {
            Debug.Log("공격");
            hitPlayer = other.GetComponent<cshHitPlayer>();
            hitPlayer.OnTakeDamage(10f);
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
      weaponCollider.enabled = true;
    }

    private void OffCollider()
    {
        weaponCollider.enabled = false;
    }

}
