using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Controller : MonoBehaviour {

    public float timer = 10f;
    public float radius = 5.0f;
    public float power = 10.0f;

	// Use this for initialization
	void Start () {
        timer = 10f;
	}
	
    void FixedUpdate()
    {
        //decrement the timer on the bomb
        timer -= .01f;
        if(timer <= 0)
        {
            explode();
        }
    }


	// Update is called once per frame
	void Update () {
		
	}


    void explode()
    {
        //do the exploding
        Vector3 explosionPos = transform.position;
        Collider2D[] colliders = Physics2D.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            
            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
    }


}
