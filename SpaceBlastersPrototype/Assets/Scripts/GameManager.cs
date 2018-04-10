using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject blackHolePowerUp;
    public GameObject rbPowerUp;
    public float spawnTimer = 0f;
    public bool powerUpOut = false;
   

	// Use this for initialization
	void Start () {
        spawnTimer = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(spawnTimer + 15 < Time.time && powerUpOut == false)
        {
            spawnPowerup();
            spawnTimer = Time.time;
        }
	}

    private void spawnPowerup()
    {
        int randomNum;
        System.Random rand = new System.Random();
        randomNum = rand.Next(1, 8);
        Vector3 room1 = new Vector3(50, 50);
        Vector3 room2 = new Vector3(-50, 50);
        Vector3 room3 = new Vector3(50, -50);
        Vector3 room4 = new Vector3(-50, -50);

        switch(randomNum){
            case 1: 
                GameObject blackHole = Instantiate(blackHolePowerUp, room1, new Quaternion(0,0,0,0)) as GameObject;
                break;
                
            default:
                break;
        }

    }
}
