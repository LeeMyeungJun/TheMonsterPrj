using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class PlayerAttack : CharacterEntity
{
    protected GameObject explosionFx = null;
    private GameObject gameObject;

    // Start is called before the first frame update
    public override void OnTakeDamage(float _damage)
    {
        hp -= _damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
            //Instantiate(explosionFx, transform.position, transform.rotation);
            //GameLogic.Inst.AddScore((int)enemyType);
        }
    }

    private void Destroy(GameObject gameObject)
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter(Collision coll)
    {
        //explosionSfx.Play();


        if (coll.gameObject.tag == "Player")
        {
            //if (GameLogic.Inst.IsGameState(GameState.clear))
                //return;
            coll.gameObject.SendMessage("Damage", 3f);
            OnTakeDamage(3f);
            //this.Damage(3f);
        }
    }
}