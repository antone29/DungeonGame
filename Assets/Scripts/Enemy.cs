using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
   // Experince
   public int xpValue = 1;

   //Logic
   public float triggerLength = 1;
   public float chaseLength = 5;
   private bool chasing; //is enemy chasing
   private bool collidingWithPlayer; //if colliding dont move,
   private Transform playerTransform; 
   private Vector3 startingPosition;

   //Hitbox
   public ContactFilter2D filter;
   private BoxCollider2D hitbox;
   private Collider2D[] hits = new Collider2D[10];

   protected override void Start(){
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        //the correct hitbox is the one below the enemy so thats why you do GetChild, explained around 3:54:00
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
   }

   protected void FixedUpdate(){
        //is the player in range?
        if(Vector3.Distance(playerTransform.position, startingPosition) < chaseLength) {
            chasing = (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength);
            if (chasing)
            {
                if (!collidingWithPlayer){
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }else
            {
                UpdateMotor(startingPosition - transform.position);
            }

        }
        else {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
           
        }
       
       //check for overlaps
        collidingWithPlayer = false;
           //Collision work
        boxCollider.OverlapCollider(filter, hits);
        for( int i = 0; i < hits.Length; i++){
            if (hits[i] == null){
                continue;
            }
            if (hits[i].tag == "Fighter" && hits[i].name == "Player"){
                collidingWithPlayer = true;
            }

            hits[i] = null;
        }
   }

   protected override void Death() {
        Destroy(gameObject);
        GameManager.instance.experience += xpValue;
        GameManager.instance.ShowText("+" + xpValue + " xp", 30, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
   }
}
