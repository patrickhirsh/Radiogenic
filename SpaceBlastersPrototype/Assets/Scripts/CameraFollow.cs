using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public float moveSpeed = 0.125f;
    public float distance;
    public float triggerDistance;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //if(target.position.x > GameObject.Find("MainCamera").transform.position.x + 5)
        //transform.position = new Vector2(target.position.x, target.position.y);
        distance = Vector2.Distance(transform.position, target.position);
        //print(distance);
        if(distance > triggerDistance){
            transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed);
        }

	}
}
