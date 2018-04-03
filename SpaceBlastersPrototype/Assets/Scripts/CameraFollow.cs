using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public float moveSpeed = 0.125f;
    public float distance;
    public float leadDist;
    public float triggerDistance;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //if(target.position.x > GameObject.Find("MainCamera").transform.position.x + 5)
        //transform.position = new Vector2(target.position.x, target.position.y);
        Vector2 targvelo = target.gameObject.GetComponent<Rigidbody2D>().velocity;
        distance = Vector2.Distance(transform.position, target.position);
        //print(distance);
     
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x + (targvelo.x * leadDist), target.position.y + (targvelo.y * leadDist), target.position.z), moveSpeed);
        

	}
}
