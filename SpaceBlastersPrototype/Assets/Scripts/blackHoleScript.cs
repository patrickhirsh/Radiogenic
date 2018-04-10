using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackHoleScript : MonoBehaviour {

    public float radius = 15.0f;
    public float power = 10.0f;
    public float implosionTime = 0f;
    public Transform var1;
	// Use this for initialization
	void Start () {
        implosionTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        if (implosionTime + 5 < Time.time)
        {
            Rigidbody2D newR = this.GetComponent<Rigidbody2D>();
            newR.constraints = RigidbodyConstraints2D.FreezeAll;
            implode();
        }
	}
    void implode()
    {
        
        //do the exploding
        Vector3 explosionPos = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);
        foreach (Collider2D hit in colliders)
        {

            if (hit.gameObject.tag == "Player")
                Physics2D.IgnoreCollision(hit, this.GetComponent<Collider2D>());
           
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
