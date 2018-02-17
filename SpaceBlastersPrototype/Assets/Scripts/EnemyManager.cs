using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public static EnemyManager EM;

    System.Random rnd;

    int spawnRadius = 100;
    int spawnFrequency = 1;

    // scales the "percentage" our random spawn system uses.
    // useful for uniformly changing the spawn rate for all enemies. 1 = out of 100%
    float spawnProbabilityFactor = 0.5f;

    // maximum percent chance that an enemy spawns on its respective spawn call
    int enemy01ProbabilityCutoff = 100;
    int enemy02ProbabilityCutoff = 50;


    // Singleton pattern
    void Awake()
    {
        if (EM == null)
        {
            DontDestroyOnLoad(gameObject);
            EM = this;
        }
        else if (EM != this)
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        rnd = new System.Random();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // FixedUpdate is called 30 times per second
    void FixedUpdate()
    {
        if (Time.time % spawnFrequency == 0)
        {
            SpawnEnemy01();
        }
    }

    void SpawnEnemy01()
    {
        // determine the spawn probability
        double spawnProbability = Math.Sqrt((double)Time.time)*2;
        if (spawnProbability > enemy01ProbabilityCutoff)
            spawnProbability = enemy01ProbabilityCutoff;

        Console.WriteLine(spawnProbability);

        // determine if we should spawn an enemy
        if (rnd.Next(0, (int)(100*spawnProbabilityFactor)) <= spawnProbability)
        {
            // determine spawn point
            double spawnAngle = rnd.Next(1, 360) * (Math.PI / 180);
            double spawnX = Math.Cos(spawnAngle) * spawnRadius;
            double spawnY = Math.Sin(spawnAngle) * spawnRadius;

            // spawn enemy
            var enemy = Instantiate(Resources.Load("Enemy_01"), new Vector3((float)spawnX, (float)spawnY, 0), new Quaternion());
        }
    }
}
