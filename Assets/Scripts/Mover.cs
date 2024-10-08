using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class is abstract because it should be inherited from, never used directly
public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;

    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.0f;

//protected virtual lets you override elsewhere
    protected virtual void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
    }

   // 3:43 fixed update?

    protected virtual void UpdateMotor(Vector3 input){
        //reset the moveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0); 

        //swap sprite direction

        if (moveDelta.x > 0) {
            transform.localScale = Vector3.one;
            }
            
        else if (moveDelta.x < 0) {
            transform.localScale = new Vector3(-1,1,1);
        }

        //Add push vector if any
        moveDelta += PushDirection;

        //Reduce push force every frame, based off recovery spped
        //what exactly does lerp do lol
        PushDirection = Vector3.Lerp(PushDirection, Vector3.zero, pushRecoverySpeed);

        //make sure we can move in this direction, by casting a box there first. if the box returns null, we are free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null){
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        //make sure we can move in this direction, by casting a box there first. if the box returns null, we are free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2( moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null){
            transform.Translate( moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
