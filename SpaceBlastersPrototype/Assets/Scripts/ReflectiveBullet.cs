using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectiveBullet : MonoBehaviour {
    private Vector3 oldVelocity;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void hit()
    {

        //donothing
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "bullet" || coll.gameObject.tag == "Player")
            Physics2D.IgnoreCollision(coll.otherCollider, this.GetComponent<Collider2D>());
        ContactPoint2D contact = coll.contacts[0];

    }
}

