using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public GameObject blackHolePowerUp;
    public GameObject rbPowerUp;
    public float spawnTimer = 0f;
    public bool powerUpOut = false;
    public int powerUpCount = 0;
    public int blackHoleCount = 0;
    public int reflectiveBulletCount = 0;
    public bool room1Taken = false;
    public bool room2Taken = false;
    public bool room3Taken = false;
    public bool room4Taken = false;

	// Use this for initialization
	void Start () {
        spawnTimer = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(blackHolePowerUp == null && rbPowerUp == null){
            powerUpCount = 0;
        }
        if(blackHolePowerUp == null && blackHoleCount > 0)
        {
            room1Taken = false;
            room3Taken = false;
            room4Taken = false;
            room2Taken = false;
            blackHoleCount--;
        }
        if(rbPowerUp == null && reflectiveBulletCount > 0)
        {
            room2Taken = false;
            room4Taken = false;
            reflectiveBulletCount--;
        }
        if(spawnTimer + 5 < Time.time && powerUpCount < 2)
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
                if (!room1Taken)
                {
                    GameObject blackHole1 = Instantiate(blackHolePowerUp, room1, new Quaternion(0, 0, 0, 0)) as GameObject;
                    powerUpCount++;
                    room1Taken = true;
                    blackHoleCount++;
                }
                break;
            case 2:
                if (!room3Taken)
                {
                    GameObject blackHole3 = Instantiate(blackHolePowerUp, room3, new Quaternion(0, 0, 0, 0)) as GameObject;
                    powerUpCount++;
                    room3Taken = true;
                    blackHoleCount++;
                }
                break;
            case 3:
                if (!room2Taken)
                {
                    GameObject rb2 = Instantiate(blackHolePowerUp, room2, new Quaternion(0, 0, 0, 0)) as GameObject;
                    powerUpCount++;
                    room2Taken = true;
                    blackHoleCount++;
                }
                break;
            case 4:
                if (!room4Taken)
                {
                    GameObject rb4 = Instantiate(blackHolePowerUp, room4, new Quaternion(0, 0, 0, 0)) as GameObject;
                    powerUpCount++;
                    room4Taken = true;
                    blackHoleCount++;
                }
                break;
            default:
                break;
        }
     

    }
}
