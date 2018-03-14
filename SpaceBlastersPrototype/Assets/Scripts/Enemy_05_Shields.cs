using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_05_Shields : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet"){
            Debug.Log("Bullet hit shield");
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }

    }

    void hit(){


    }
}
