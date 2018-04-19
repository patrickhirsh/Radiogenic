using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_03_Controller : MonoBehaviour {

    // Use this for initialization
    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 3f;
    public float hitbox = .7f;
    private Rigidbody2D rb;
    public float dragVal = .5f;
    public float hp;
    private float periodz = 5.0f;
    public float periodzint;
    bool charge1 = false;
    float charge2 = 0;
    public float rotationSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = dragVal;
        periodz = 10f;

        //we need to assign the target here, otherwise enemies generated at runtime won't have a target
        target = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {

        Vector2 rotDirec = target.position - transform.position;
        float angle = Mathf.Atan2(rotDirec.y, rotDirec.x) * Mathf.Rad2Deg;
        angle += -90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        if(periodz < Time.time)
        {
            periodz += periodzint;
            charge1 = true;
        }
        //rb.AddForce(transform.forward * speed);
        var direction = Vector3.zero;
        //move towards the player
        if (Vector3.Distance(transform.position, target.position) > hitbox)
        {//move if distance from target is greater than 1
            if (charge1)
            {
                
                if (charge2 > 10.0f)
                {
                    
                    charge1 = false;
                    charge2 = 0;
                    direction = target.position - transform.position;

                    rb.AddForce(direction.normalized * (speed * 7), ForceMode2D.Impulse);

                }
                else
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = 0;
                    charge2 += .1f;
                }
            }
            else
            {
                direction = target.position - transform.position;
                rb.AddForce(direction.normalized * speed, ForceMode2D.Force);

                //Mathf.Clamp(rb.velocity.magnitude, -3f, 3f);
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}

    void hit(){
        hp--;
        if(hp <= 0){
            ParticleManager.generateEnemy3Explosion(this.gameObject);
            this.gameObject.SetActive(false);
            EnemyManager.enemyCaches[2].Push(this.gameObject);
        }

    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "bullet"){
            hit();
            Destroy(col.gameObject);
        }
    }
}
