using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager EM;

    // used for generating random probability values
    public static System.Random rnd;

    // running count of enemies in the scene
    public static int Enemy01Count;
    public static int Enemy02Count;
    public static int Enemy03Count;
    public static int Enemy04Count;
    public static int Enemy05Count;


    #region PUBLIC METHODS

    // This method should be called every fixed update from each Enemy_05 object
    // Spawns enemies on an interval from the Enemy_05 spawn points
    public static void enemy05ClusterSpawn(GameObject target)
    {
        int spawnProbability = 20;  // probability of an Enemy_01 spawning any given fixedUpdate during a spawn interval
        int spawnInterval = 7;      // interval offset (in seconds). Every x seconds, a one second spawn interval occurs
        double spawnRadius = 3;     // distance from the target the enemies should spawn

        // check if we're within the spawn interval
        if ((int)Time.time % spawnInterval == 0)
        {
            // determine if we should spawn an enemy
            if (rnd.Next(0, 100) <= spawnProbability)
            {
                // set the spawn positions relative to the target enemy
                Debug.Log(target.transform.rotation.z);
                double topSpawnAngle = (Math.PI / 2.0) + target.transform.rotation.ToEuler().z;
                double rightSpawnAngle = ((11.0/6.0)*Math.PI) + target.transform.rotation.ToEuler().z;
                double leftSpawnAngle = ((7.0/6.0)*Math.PI) + target.transform.rotation.ToEuler().z;

                double spawnX1 = (Math.Cos(topSpawnAngle) * spawnRadius) + target.transform.position.x;
                double spawnY1 = (Math.Sin(topSpawnAngle) * spawnRadius) + target.transform.position.y;
                double spawnX2 = (Math.Cos(rightSpawnAngle) * spawnRadius) + target.transform.position.x;
                double spawnY2 = (Math.Sin(rightSpawnAngle) * spawnRadius) + target.transform.position.y;
                double spawnX3 = (Math.Cos(leftSpawnAngle) * spawnRadius) + target.transform.position.x;
                double spawnY3 = (Math.Sin(leftSpawnAngle) * spawnRadius) + target.transform.position.y;

                // spawn enemy
                UnityEngine.Object enemy1 = Instantiate(Resources.Load("Enemy_01"), new Vector3((float)spawnX1, (float)spawnY1, 0), new Quaternion());
                UnityEngine.Object enemy2 = Instantiate(Resources.Load("Enemy_01"), new Vector3((float)spawnX2, (float)spawnY2, 0), new Quaternion());
                UnityEngine.Object enemy3 = Instantiate(Resources.Load("Enemy_01"), new Vector3((float)spawnX3, (float)spawnY3, 0), new Quaternion());
            }
        }
    }

    #endregion


    #region INTERNAL SPAWN MANAGEMENT SYSTEM

    // determines the distance from the origin at which enemies spawn
    int spawnRadius = 50;

    // scales the "percentage" our random spawn system uses.
    // useful for uniformly changing the spawn rate for all enemies. 1 = 1*100 = out of 100%
    float spawnProbabilityFactor = 1f;

    // spawn probability calculation methods
    double enemy01SpawnProbability(double time) { return Math.Sqrt(time); }
    double enemy02SpawnProbability(double time) { return time / 25; }
    double enemy03SpawnProbability(double time) { return time / 18; }
    double enemy04SpawnProbability(double time) { return time / 50; }

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

    // An abstract enemy spawning method. This should be called once for each enemy every fixed update
    // Each time this is called, the system tries to spawn an enemy based on the given parameters.
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

    #endregion
}
