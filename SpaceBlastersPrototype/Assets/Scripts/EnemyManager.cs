using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager EM;

    // used for generating random probability values
    public static System.Random rnd;

    static int maxEnemy01 = 750;
    static int maxEnemy02 = 50;
    static int maxEnemy03 = 100;
    static int maxEnemy04 = 150;
    static int maxEnemy05 = 30;
    static int maxEnemy06 = 5;

    static Stack<GameObject> enemy01Cache = new Stack<GameObject>();
    static Stack<GameObject> enemy02Cache = new Stack<GameObject>();
    static Stack<GameObject> enemy03Cache = new Stack<GameObject>();
    static Stack<GameObject> enemy04Cache = new Stack<GameObject>();
    static Stack<GameObject> enemy05Cache = new Stack<GameObject>();
    static Stack<GameObject> enemy06Cache = new Stack<GameObject>();

    public static List<Stack<GameObject>> enemyCaches = new List<Stack<GameObject>>() { enemy01Cache, enemy02Cache, enemy03Cache, enemy04Cache, enemy05Cache, enemy06Cache };
    static List<int> enemyMaxes = new List<int>() { maxEnemy01, maxEnemy02, maxEnemy03, maxEnemy04, maxEnemy05, maxEnemy06 };
    static List<string> enemyTypes = new List<string>() { "Enemy_01", "Enemy_02", "Enemy_03", "Enemy_04", "Enemy_05", "Enemy_06" };




    #region PUBLIC METHODS

    // This method should be called every fixed update from each Enemy_05 prefab
    // Spawns enemies on an interval from the Enemy_05 spawn points
    public static void enemy05ClusterSpawn(GameObject target)
    {
        int spawnProbability = 30;  // probability of an Enemy_01 spawning any given fixedUpdate during a spawn interval
        int spawnInterval = 13;     // interval offset (in seconds). Every x seconds, a one second spawn interval occurs
        double spawnRadius = 2;     // distance from the target the enemies should spawn
        float spawnThrust = 2000;    // thrust at which enemy01's spawn from enemy05

        // check if we're within the spawn interval
        if ((int)Time.time % spawnInterval == 0)
        {
            // determine if we should spawn an enemy
            if ((rnd.Next(0, 100) <= spawnProbability) && (enemyCaches[0].Count > 0))
            {
                // set the spawn positions relative to the target enemy
                double topSpawnAngle = (Math.PI / 2.0) + target.transform.rotation.ToEuler().z;
                double rightSpawnAngle = ((11.0/6.0)*Math.PI) + target.transform.rotation.ToEuler().z;
                double leftSpawnAngle = ((7.0/6.0)*Math.PI) + target.transform.rotation.ToEuler().z;

                double spawnX1 = (Math.Cos(topSpawnAngle) * spawnRadius) + target.transform.position.x;
                double spawnY1 = (Math.Sin(topSpawnAngle) * spawnRadius) + target.transform.position.y;
                double spawnX2 = (Math.Cos(rightSpawnAngle) * spawnRadius) + target.transform.position.x;
                double spawnY2 = (Math.Sin(rightSpawnAngle) * spawnRadius) + target.transform.position.y;
                double spawnX3 = (Math.Cos(leftSpawnAngle) * spawnRadius) + target.transform.position.x;
                double spawnY3 = (Math.Sin(leftSpawnAngle) * spawnRadius) + target.transform.position.y;

                // activate enemies
                var enemy1 = enemyCaches[0].Pop();
                var enemy2 = enemyCaches[0].Pop();
                var enemy3 = enemyCaches[0].Pop();
                enemy1.SetActive(true);
                enemy2.SetActive(true);
                enemy3.SetActive(true);
                enemy1.transform.position = new Vector3((float)spawnX1, (float)spawnY1, 0);
                enemy2.transform.position = new Vector3((float)spawnX2, (float)spawnY2, 0);
                enemy3.transform.position = new Vector3((float)spawnX3, (float)spawnY3, 0);

                // apply thrust in an outward direction
                enemy1.GetComponent<Rigidbody2D>().AddForce(new Vector2(spawnThrust * Mathf.Cos((float)topSpawnAngle), spawnThrust * Mathf.Sin((float)topSpawnAngle)));
                enemy2.GetComponent<Rigidbody2D>().AddForce(new Vector2(spawnThrust * Mathf.Cos((float)rightSpawnAngle), spawnThrust * Mathf.Sin((float)rightSpawnAngle)));
                enemy3.GetComponent<Rigidbody2D>().AddForce(new Vector2(spawnThrust * Mathf.Cos((float)leftSpawnAngle), spawnThrust * Mathf.Sin((float)leftSpawnAngle)));
            }
        }
    }

    #endregion

    #region INTERNAL SPAWN MANAGEMENT SYSTEM

    // determines the distance from the origin at which enemies spawn
    int spawnRadius = 130;

    // scales the "percentage" our random spawn system uses.
    // useful for uniformly changing the spawn rate for all enemies. 1 = 1*100 = out of 100%
    float spawnProbabilityFactor = 2f;

    // spawn probability calculation methods
    double enemy01SpawnProbability(double time) { return Math.Sqrt(time); }
    double enemy02SpawnProbability(double time) { return time / 25; }
    double enemy03SpawnProbability(double time) { return time / 18; }
    double enemy04SpawnProbability(double time) { return time / 50; }
    double enemy05SpawnProbability(double time) { return time / 50; }
    double enemy06SpawnProbability(double time) { return time / 50; }

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
        generateEnemyPool();

    }

    // FixedUpdate is called 30 times per second
    void FixedUpdate()
    {
        TrySpawnEnemy(0, 1, 20, enemy01SpawnProbability);
        TrySpawnEnemy(1, 10, 4, enemy02SpawnProbability);
        TrySpawnEnemy(2, 5, 10, enemy03SpawnProbability);
        TrySpawnEnemy(3, 1, 12, enemy04SpawnProbability);
        TrySpawnEnemy(4, 14, 3, enemy05SpawnProbability);
        //TrySpawnEnemy(5, 10, 4, enemy06SpawnProbability);


    }

    void generateEnemyPool()
    {
        // for each enemy cache, populate it with (inactive) enemies of that type.
        // the number of enemies added to each cache is dependent on the maxEnemy variables.
        for (int i = 0; i < enemyCaches.Count; i++)
            for (int j = 0; j < enemyMaxes[i]; j++)
            {
                GameObject enemy = Instantiate(Resources.Load(enemyTypes[i]), new Vector3(-300, 300, 0), new Quaternion()) as GameObject;
                enemy.SetActive(false);
                enemyCaches[i].Push(enemy);
            }        
    }

    // An abstract enemy spawning method. This should be called once for each enemy every fixed update
    // Each time this is called, the system tries to spawn an enemy based on the given parameters.
    void TrySpawnEnemy(int enemyType, int spawnInterval, int probabilityCutoff, Func<double, double> calculateSpawnProbability)
    {
        // check if we're within the spawn interval
        if (((int)Time.time % spawnInterval == 0) && (enemyCaches[enemyType].Count > 0))
        {
            // determine the spawn probability
            double spawnProbability = calculateSpawnProbability((double)Time.time);
            if (spawnProbability > probabilityCutoff)
                spawnProbability = probabilityCutoff;

            // determine if we should spawn an enemy
            if (rnd.Next(0, (int)(100 * spawnProbabilityFactor)) <= spawnProbability)
            {
                int finalRadius = spawnRadius;

                // spawn enemies closer for the first 15 seconds to apply immediate pressure
                if (Time.time < 10)
                    finalRadius = spawnRadius / 3;

                // enemy 5's should spawn in the playable area
                if (enemyType == 4)
                    finalRadius = spawnRadius / 3;

                // determine spawn point
                double spawnAngle = rnd.Next(1, 360) * (Math.PI / 180);
                double spawnX = Math.Cos(spawnAngle) * finalRadius;
                double spawnY = Math.Sin(spawnAngle) * finalRadius;

                // activate enemy
                if (enemyCaches[enemyType].Count != 0)
                {
                    var enemy = enemyCaches[enemyType].Pop();
                    enemy.SetActive(true);
                    enemy.transform.position = new Vector3((float)spawnX, (float)spawnY, 0);
                }
            }
        }
    }

    #endregion
}
