using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    //Damage

    public int damage = 1;
    public float pushForce = 5;

    protected override void OnCollide(Collider2D coll)
    {
       //check if we hit player
       if (coll.tag == "Fighter" && coll.name == "Player")
       {
        //Create a new damage object, before sending it to the player
         Damage dmg = new Damage()
            {
                damangeAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg); //this is sending over the "RecieveDamage" function to the thing you just hit
       }
    }
  
}


//4:16:51