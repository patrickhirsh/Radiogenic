using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour {

    public Transform target;

    public float accFactor = .0000001f;
    public float xVel;
    public float yVel;
    public float xAcc;
    public float yAcc;

    void Awake()
    {
        Application.targetFrameRate = 10;
    }

	// Use this for initialization
	void Start ()
    {
        
	}

    // Update is called once per frame
	void Update ()
    {
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        if (Vector2.Distance(transform.position, target.position) > 1f)
        {
            float xDelta = target.position.x - transform.position.x;
            float yDelta = target.position.y - transform.position.y;

            xAcc = accFactor * (xDelta / Mathf.Abs(yDelta));
            yAcc = accFactor * (yDelta / Mathf.Abs(xDelta));

            
            xVel += xAcc;
            yVel += yAcc;

            transform.position = new Vector3(transform.position.x + xVel, transform.position.y + yVel, 0);
        }
    }
}
