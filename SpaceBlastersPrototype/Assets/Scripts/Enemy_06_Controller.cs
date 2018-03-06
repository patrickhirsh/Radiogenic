using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_06_Controller : MonoBehaviour {

    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 3f;
    public float hitbox = .7f;
    public float hp = 3.0f;
    public float DragVal = .5f;
    public float periodz1;
    public float periodz2;
    public float periodz3;
    private bool charge;

    private Rigidbody2D rb;

    public float rotationSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = DragVal;

        //we need to assign the target here, otherwise enemies generated at runtime won't have a target
        target = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        if (!charge)
        {

            //rotate to look at the player
            //transform.LookAt(target.position);
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            //rb.AddForce(transform.forward * speed);
            var direction2 = Vector3.zero;
            //move towards the player
            if (Vector3.Distance(transform.position, target.position) > hitbox)
            {//move if distance from target is greater than 1
                direction2 = target.position - transform.position;
                rb.AddForce(direction.normalized * speed, ForceMode2D.Force);

                Mathf.Clamp(rb.velocity.magnitude, .3f, 3f);
            }
            else
            {
                //reset direction every update
                //set direction to be pointing towards player
                direction2 = target.position - transform.position;
                //add forst in the desired direction at the desired speed
                rb.AddForce(direction.normalized * speed * -1, ForceMode2D.Force);

            }
            periodz1 += .01f;
            if(periodz1 > periodz2){
                periodz2 += periodz3;
                periodz1 = 0;
                charge = true;
            }
        }
        else{
            charge = false;
            Vector2 direction = target.position - transform.position;
            rb.AddForce(direction.normalized * speed * 3, ForceMode2D.Force);
        }
    }

    void Hit()
    {
        //we got hit
        hp--;
        if (hp == 0.0f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hit an Enemy_02");
        if (col.gameObject.tag == "bullet")
        {
            if (col.otherCollider.GetType() == typeof(CircleCollider2D))
            {
                Hit();
            }
            else
            {
                Destroy(col.gameObject);
            }
        }
        else if (col.gameObject.tag == "player")
        {
            //use 
            col.gameObject.SendMessage("Hit");
        }
        else
        {
            //probs hit another enmey zzzzzz
        }
    }
}
