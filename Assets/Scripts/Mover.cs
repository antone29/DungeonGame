using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class is abstract because it should be inherited from, never used directly
public abstract class Mover : Fighter
{
     private BoxCollider2D boxCollider;

    private Vector3 moveDelta;
    private RaycastHit2D hit;
    protected float ySpeed = 0.75f;
    protected float xSpeed = 1.0f;

//protected virtual lets you override elsewhere
    protected virtual void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
    }


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
