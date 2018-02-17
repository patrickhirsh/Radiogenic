using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 3f;
    public float hitbox = .7f;
    private Rigidbody2D rb;
    public float dragVal = .5f;
    public float hp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = dragVal;

        //we need to assign the target here, otherwise enemies generated at runtime won't have a target
        target = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
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

    //This is the function we need to call from the bullet object when we hit the correct collider
    void Hit()
    {
        if(hp > 1)
        {
            hp--;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //This SHOULD run when the destroy method is called on a game object
    void OnDestroy()
    {
        Debug.Log("OH no we was destroy");
        //Activate destroyed particle effect

    }
}
