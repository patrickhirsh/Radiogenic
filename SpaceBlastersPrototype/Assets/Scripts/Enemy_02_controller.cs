using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_02_controller : MonoBehaviour {

    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 3f;
    public float hitbox = .7f;
    public float DragVal = .5f;
    private Rigidbody2D rb;

    public float rotationSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = DragVal;
    }

    void FixedUpdate()
    {

        //rotate to look at the player
        //transform.LookAt(target.position);
        var neededRotation = Quaternion.LookRotation(target.position - transform.position);
        Quaternion.RotateTowards(transform.rotation, target.rotation, rotationSpeed);
        //rb.AddForce(transform.forward * speed);
        var direction = Vector3.zero;
        //move towards the player
        if (Vector3.Distance(transform.position, target.position) > hitbox)
        {//move if distance from target is greater than 1
            direction = target.position - transform.position;
            rb.AddRelativeForce(direction.normalized * speed, ForceMode2D.Force);

            Mathf.Clamp(rb.velocity.magnitude, .3f, 3f);
        }
    }

    void CheckCol(Collision2D col)
    {

        if(col.otherCollider.GetType() == typeof(CircleCollider2D))
        {
            //do the destroy
        }
        else
        {
            //destroy the col object, which is probs a bullets
        }
    }
}
