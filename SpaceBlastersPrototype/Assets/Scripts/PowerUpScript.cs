using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

   
	// Use this for initialization
	void Start () {
   
	}
	
	// Update is called once per frame
    void FixedUpdate () 
        {
            
        }
	
private void OnCollisionEnter2D(Collision2D collision)
{

    if (collision.gameObject.tag == "Player")
    {
        Destroy(this.gameObject);
    }
}
   
    }


        


    

