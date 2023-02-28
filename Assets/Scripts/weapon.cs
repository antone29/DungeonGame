using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : Collidable
{
    // Damage struct
    public int damagePoint = 1;
    public float pushForce = 2.0f; //pushes enemy away

    // Upgrade
    public int weaponLevel = 0; //weapon level is upgradable
    private SpriteRenderer spriteRenderer; //private so needs to be assigned in start, already technically delcared but we are gonna override it

    // Swing
    private float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start() {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    private void Swing()
    {
        Debug.Log("Swing");
    }

}
