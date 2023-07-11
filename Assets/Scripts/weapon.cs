using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Damage struct
    public int damagePoint = 1;
    public float pushForce = 2.0f; //pushes enemy away

    // Upgrade
    public int weaponLevel = 0; //weapon level is upgradable
    private SpriteRenderer spriteRenderer; //private so needs to be assigned in start, already technically delcared but we are gonna override it

    // Swing - animation code starts around 4:15
    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start() {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected override void Update() {
        base.Update();

        //allows player to swing if there has been enough time since previous swing(key board smash is no no)
        if(Input.GetKeyDown(KeyCode.Space)){
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter") 
        {
            if (coll.name == "Player")
                return;

            // Create a new damage object, then we'll send it to the fighter we've hit
            Damage dmg = new Damage()
            {
                damangeAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg); //this is sending over the "RecieveDamage" function to the thing you just hit
           
            
        }
        
    }

    private void Swing()
    {
        anim.SetTrigger("Swing");

        
    }

}
