using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapRoom_Controller : MonoBehaviour {

    public float rotateSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void FixedUpdate()
    {
 
        transform.Rotate(Vector3.back * rotateSpeed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "bullet")
        {
            Debug.Log("A Bullet Hit");
            Destroy(col.gameObject);
        }
    }
}
