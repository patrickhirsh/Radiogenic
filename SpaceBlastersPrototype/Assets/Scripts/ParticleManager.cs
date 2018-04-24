using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    public static ParticleManager PM;
    public static bool useParticles;  

    // Singleton pattern
    void Awake()
    {
        if (PM == null)
        {
            DontDestroyOnLoad(gameObject);
            PM = this;
        }
        else if (PM != this)
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public static void generateEnemy1Explosion(GameObject enemy)
    {
        Vector3 pos = enemy.transform.position;
        var explosion = Instantiate(Resources.Load("Particles/Explosions/enemy1Explosion"), pos, new Quaternion()) as GameObject;
        Destroy(explosion, 2);
    }

    public static void generateEnemy2Explosion(GameObject enemy)
    {
        Vector3 pos = enemy.transform.position;
        var explosion = Instantiate(Resources.Load("Particles/Explosions/enemy2Explosion"), pos, new Quaternion()) as GameObject;
        Destroy(explosion, 2);
    }

    public static void generateEnemy3Explosion(GameObject enemy)
    {
        Vector3 pos = enemy.transform.position;
        var explosion = Instantiate(Resources.Load("Particles/Explosions/enemy3Explosion"), pos, new Quaternion()) as GameObject;
        Destroy(explosion, 2);
    }

    public static void generateEnemy4Explosion(GameObject enemy)
    {
        Vector3 pos = enemy.transform.position;
        var explosion1 = Instantiate(Resources.Load("Particles/Explosions/enemy4Explosion"), pos, new Quaternion()) as GameObject;
        var explosion2 = Instantiate(Resources.Load("Particles/Explosions/enemy4Explosion2"), pos, new Quaternion()) as GameObject;
        Destroy(explosion1, 2);
        Destroy(explosion2, 2);
    }

    public static void generateEnemy5Explosion(GameObject enemy)
    {
        Vector3 pos = enemy.transform.position;
        var explosion1 = Instantiate(Resources.Load("Particles/Explosions/enemy5Explosion1"), pos, new Quaternion()) as GameObject;
        var explosion2 = Instantiate(Resources.Load("Particles/Explosions/enemy5Explosion2"), pos, new Quaternion()) as GameObject;
        var explosion3 = Instantiate(Resources.Load("Particles/Explosions/enemy5Explosion3"), pos, new Quaternion()) as GameObject;
        var explosion4 = Instantiate(Resources.Load("Particles/Explosions/enemy5Explosion4"), pos, new Quaternion()) as GameObject;
        var explosion5 = Instantiate(Resources.Load("Particles/Explosions/enemy5Explosion5"), pos, new Quaternion()) as GameObject;
        Destroy(explosion1, 5);
        Destroy(explosion2, 5);
        Destroy(explosion3, 5);
        Destroy(explosion4, 5);
        Destroy(explosion5, 5);
    }

    public static void generateBulletTrail(GameObject bullet)
    {
        Vector3 pos = bullet.transform.position;
        var bulletTrail = Instantiate(Resources.Load("Particles/Machine Gun"), pos, new Quaternion()) as GameObject;
        bulletTrail.transform.parent = bullet.transform;
    }
}
