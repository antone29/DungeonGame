using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // Damage struct
    public int[] damagePoint = {1, 2, 3, 4, 5, 6, 7};
    public float[] pushForce = {2.0f, 2.2f, 2.5f, 3f, 3.2f, 3.5f, 4f}; //pushes enemy away

    // Upgrade
    public int weaponLevel = 0; //weapon level is upgradable
    public SpriteRenderer spriteRenderer; //private so needs to be assigned in start, already technically delcared but we are gonna override it
    

    // Swing - animation code starts around 4:15
    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;

    // private void Awake(){
    //     spriteRenderer = GetComponent<SpriteRenderer();
    // }

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
                damangeAmount = damagePoint[weaponLevel],
                origin = transform.position,
                pushForce = pushForce[weaponLevel]
            };

            coll.SendMessage("ReceiveDamage", dmg); //this is sending over the "RecieveDamage" function to the thing you just hit
           
            
        }
        
    }

    private void Swing()
    {
        anim.SetTrigger("Swing");

        
    }

    public void UpgradeWeapon()
    {
        weaponLevel++;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];

        //Change stats %%
    }

    public void SetWeaponLevel(int level){
         weaponLevel = level;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];

    }

}
