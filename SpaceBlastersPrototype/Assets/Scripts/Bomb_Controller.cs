using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Controller : MonoBehaviour {

<<<<<<< HEAD
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


=======
	// Use this for initialization
	void Start () {
		
	}
	
>>>>>>> e90afef2dae5819a4a89b64ec701622dc620c202
	// Update is called once per frame
	void Update () {
		
	}
<<<<<<< HEAD


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


=======
>>>>>>> e90afef2dae5819a4a89b64ec701622dc620c202
}
