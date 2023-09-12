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
        Debug.Log("Ãæµ¹");
        //if other == monster 
        //other.takeondamage(waeapon.damage)

    }

    private void OnCollider()
    {
        Debug.Log("ÄÑÁü");
        weaponCollider.enabled = true;
    }
    private void OffCollider()
    {
        Debug.Log("²¨Áü");
        //weaponCollider.enabled = false;
    }

}
