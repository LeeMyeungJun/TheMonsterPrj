using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshHitMonster : MonoBehaviour
{
    public Collider weaponCollider;

    //void OnCollisionEnter(Collision coll)
    //{
    //    if(coll.gameObject.tag == "Sword")
    //    {
    //        //Destroy(coll.gameObject);
    //        Debug.Log("Hit");
    //    }
    //}


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�浹");
        //if other == monster 
        //other.takeondamage(waeapon.damage)

    }

    private void OnCollider()
    {
        Debug.Log("����");
        weaponCollider.enabled = true;
    }
    private void OffCollider()
    {
        Debug.Log("����");
        //weaponCollider.enabled = false;
    }

}
