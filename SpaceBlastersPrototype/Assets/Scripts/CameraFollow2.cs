using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour {
    public Transform target;
    public float moveSpeed = 0.125f;
    public float _distance;
    public float _triggerDistance;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if(target.position.x > GameObject.Find("MainCamera").transform.position.x + 5)
        //transform.position = new Vector2(target.position.x, target.position.y);
        _distance = Vector2.Distance(transform.position, target.position);
        moveSpeed = _distance - _triggerDistance;
        if(_distance > _triggerDistance){
            transform.position = Vector3.Slerp(transform.position, target.position, moveSpeed);
        }

	}
}
