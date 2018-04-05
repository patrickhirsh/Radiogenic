using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_06_Controller : MonoBehaviour
{

    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 3f;
    public float hitbox = .7f;
    public GameObject BombSpawnPoint;
    public float dragVal = .5f;
    public float hp = 3.0f;
    public float DragVal = .5f;
    public float periodz1;
    public float periodz2;
    public float periodz3 = -5f;
    public float periodz4 = -5.5f;
    private bool charge;

    private Rigidbody2D rb;

    public float rotationSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = dragVal;

        rb.drag = DragVal;
        
        //we need to assign the target here, otherwise enemies generated at runtime won't have a target
        target = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {

        Vector2 rotvec = target.position - transform.position;
        float angle = Mathf.Atan2(rotvec.y, rotvec.x) * Mathf.Rad2Deg;
        angle += -90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.position) > hitbox)
        {
            //reset direction every update
            var direction = Vector3.zero;
            //set direction to be pointing towards player
            direction = target.position - transform.position;
            //add forst in the desired direction at the desired speed
            rb.AddForce(direction.normalized * speed, ForceMode2D.Force);

            //clamp so we don't go too fast
            Mathf.Clamp(rb.velocity.magnitude, .3f, 3f);
        }
        else
        {
            //reset direction every update
            var direction = Vector3.zero;
            //set direction to be pointing towards player
            direction = target.position - transform.position;
            //add forst in the desired direction at the desired speed
            rb.AddForce(direction.normalized * speed * -1, ForceMode2D.Force);

            //clamp so we don't go too fast
            Mathf.Clamp(rb.velocity.magnitude, .3f, 3f);
        }
        periodz1 += .05f;
        periodz3 += .05f;
        periodz4 += .05f;
        if(periodz1 > periodz2)
        {
            periodz1 = 0;
            spawnBomb();
        }
        if(periodz3 > periodz2)
        {
            periodz3 = 0;
            chargeatem();
        }
        if (periodz4 > periodz2)
        {
            periodz4 = 0;
            endcharge();
        }
    }

    private void endcharge()
    {
        //reset direction every update
        var direction = Vector3.zero;
        //set direction to be pointing towards player
        direction = target.position - transform.position;
        //add forst in the desired direction at the desired speed
        rb.AddForce(direction.normalized * speed * -400, ForceMode2D.Force);

        //clamp so we don't go too fast
        Mathf.Clamp(rb.velocity.magnitude, .3f, 3f);
    }

    private void chargeatem()
    {
        Debug.Log("jumping");
        var direction = Vector3.zero;
        direction = target.position - transform.position;
        rb.AddForce(direction.normalized * speed * 400, ForceMode2D.Force);
    }

    private void spawnBomb()
    {
        UnityEngine.GameObject lebomb = (GameObject)Instantiate(Resources.Load("Bomb"), BombSpawnPoint.transform.position, new Quaternion());
        Rigidbody2D bombrb = lebomb.GetComponent<Rigidbody2D>();
        bombrb.velocity = this.rb.velocity;
    }

    void hit()
    {
        //we got hit
        hp--;
        if (hp <= 0.0f)
        {
            this.gameObject.SetActive(false);
            EnemyManager.enemyCaches[5].Push(this.gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bullet")
        {
            hit();
            Destroy(col.gameObject);

        }
    }

    //This SHOULD run when the destroy method is called on a game object
    void OnDestroy()
    {
        //Activate destroyed particle effect
    }

 
}
