using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackHoleScript : MonoBehaviour {

    public float radius = 5.0f;
    public float power = 10.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
    void explode()
    {
        
        //do the exploding
        Vector3 explosionPos = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);
        foreach (Collider2D hit in colliders)
        {

            Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();

            var direction = Vector3.zero;
            if (rb != null)
            {
                direction = rb.transform.position - transform.position;

                rb.AddForce(-direction.normalized * power, ForceMode2D.Impulse);
             
            }
        }

    }
}
