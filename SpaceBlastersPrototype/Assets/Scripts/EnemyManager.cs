using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public static EnemyManager EM;

    System.Random rnd;

    int spawnRadius = 50;

    // scales the "percentage" our random spawn system uses.
    // useful for uniformly changing the spawn rate for all enemies. 1 = 1*100 = out of 100%
    float spawnProbabilityFactor = 1f;

    // running count of enemies in the scene
    public static int Enemy01Count;
    public static int Enemy02Count;
    public static int Enemy03Count;
    public static int Enemy04Count;


    // spawn probability calculation methods
    public double enemy01SpawnProbability(double time) { return Math.Sqrt(time); }
    public double enemy02SpawnProbability(double time) { return time / 25; }
    public double enemy03SpawnProbability(double time) { return time / 18; }
    public double enemy04SpawnProbability(double time) { return time / 50; }

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

    // FixedUpdate is called 30 times per second
    void FixedUpdate()
    {
        TrySpawnEnemy("Enemy_01", 1, 100, enemy01SpawnProbability);
        TrySpawnEnemy("Enemy_02", 1, 30, enemy02SpawnProbability);
        TrySpawnEnemy("Enemy_03", 5, 80, enemy03SpawnProbability);
        TrySpawnEnemy("Enemy_04", 1, 50, enemy04SpawnProbability);

    }

    void TrySpawnEnemy(string enemyType, int spawnInterval, int probabilityCutoff, Func<double, double> calculateSpawnProbability)
    {
        // check if we're within the spawn interval
        if ((int)Time.time % spawnInterval == 0)
        {
            // determine the spawn probability
            double spawnProbability = calculateSpawnProbability((double)Time.time);
            if (spawnProbability > probabilityCutoff)
                spawnProbability = probabilityCutoff;

            // determine if we should spawn an enemy
            if (rnd.Next(0, (int)(100 * spawnProbabilityFactor)) <= spawnProbability)
            {
                // determine spawn point
                double spawnAngle = rnd.Next(1, 360) * (Math.PI / 180);
                double spawnX = Math.Cos(spawnAngle) * spawnRadius;
                double spawnY = Math.Sin(spawnAngle) * spawnRadius;

                // spawn enemy
                var enemy = Instantiate(Resources.Load(enemyType), new Vector3((float)spawnX, (float)spawnY, 0), new Quaternion());
            }
        }
    }
}
