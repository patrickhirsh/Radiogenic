using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectiveBullet : MonoBehaviour {
    
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
        {
            Physics2D.IgnoreCollision(coll.otherCollider, this.GetComponent<Collider2D>());
        }
       
        Vector3 oldVelocity = this.GetComponent<Rigidbody2D>().velocity;
        ContactPoint2D contact = coll.contacts[0];
        Vector3 reflectedVelocity = Vector3.Reflect(oldVelocity, contact.normal);
        this.GetComponent<Rigidbody2D>().velocity = reflectedVelocity;
        Quaternion rotation = Quaternion.FromToRotation(oldVelocity, reflectedVelocity);
        transform.rotation = rotation * transform.rotation; 


    }
}

