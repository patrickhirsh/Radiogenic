﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLayerSynthControls : MonoBehaviour
{
    public GameObject bulletMuzzle;
    public GameObject reflectiveBullet;
    public GameObject bulletPrefab;
    public GameObject blackHole;
    private Vector2 velocity;
    public float velocityRate = 20f;
    public float accelerationRate;
    Rigidbody2D rb = new Rigidbody2D();
    float bulletDistance = .1f;
    float shotGunInterval = 0;
    float powerUpTimer = 0f;
    float dashInterval = 0f;
    bool shotgun = false;
    bool dash = true;
    bool blackHolePowerUp = true;
    bool reflectiveBulletPowerUp = false;
    bool powerUpInUse = true;
    public int thrust = 1000;
    public int thrust2 = 1200;
    public int blackHoleSpeed = 1000;
    public float variance = 0.2f;
    public float variance2 = 1f;
    public int hp = 10;
    public GameObject DamageSprite;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bulletPrefab = (GameObject)Resources.Load("bullet");
    }

    private void Rotate()
    {

    }

    void hit(){
        hp--;
        ScreenShake ss = Camera.main.GetComponent<ScreenShake>();
        //ss.shakeDuration += .5f;
        if(hp <= 0)
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Enemy")
        {
            if(dashInterval +.3 > Time.time){
                //do nothing
            }
            else
            {
                hit();
                DamageSprite.SetActive(true);
                if (collision.gameObject.name == "Enemy_01" || collision.gameObject.name == "Enemy_03" || collision.gameObject.name == "Enemy_04"){
                    Destroy(collision.gameObject);
                }
            }
                

        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);


        velocity.x = 0;
        velocity.y = 0;
        //        velocity.x = Input.GetAxis("Horizontal") * velocityRate;
        //        velocity.y = Input.GetAxis("Vertical") * velocityRate;
        if (Input.GetKey(KeyCode.W))
        {
            velocity.y = 10f * velocityRate;

            if (Input.GetKey(KeyCode.D))
            {
                velocity.x = 10f * velocityRate;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                velocity.x = -10f * velocityRate;
            }
            else
            {
                if (velocity.x > 0)
                {
                    velocity.x -= 5f;
                }
                else if (velocity.x < 0)
                {
                    velocity.x += 5f;
                }
            }

        }

        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            velocity.x = -10f * velocityRate;
            velocity.y = 10f * velocityRate;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            velocity.x = 10f * velocityRate;
            velocity.y = 10f * velocityRate;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -10f * velocityRate;
            if (Input.GetKey(KeyCode.W))
            {
                velocity.y = 10f * velocityRate;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                velocity.y = -10f * velocityRate;
            }
            else
            {
                if (velocity.y > 0)
                {
                    velocity.y -= 5f;
                }
                else if (velocity.x < 0)
                {
                    velocity.y += 5f;
                }
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            velocity.y = -10f * velocityRate;

            if (Input.GetKey(KeyCode.D))
            {
                velocity.x = 10f * velocityRate;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                velocity.x = -10f * velocityRate;
            }
            else
            {
                if (velocity.x > 0)
                {
                    velocity.x -= 5f;
                }
                else if (velocity.x < 0)
                {
                    velocity.x += 5f;
                }
            }

        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            velocity.x = 10f * velocityRate;
            velocity.y = -10f * velocityRate;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            velocity.x = -10f * velocityRate;
            velocity.y = -10f * velocityRate;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            velocity.x = 10f * velocityRate;

            if (Input.GetKey(KeyCode.W))
            {
                velocity.y = 10f * velocityRate;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                velocity.y = -10f * velocityRate;
            }
            else
            {
                if (velocity.y > 0)
                {
                    velocity.y -= 5f;
                }
                else if (velocity.x < 0)
                {
                    velocity.y += 5f;
                }
            }
        }
        else
        {
            if (velocity.x > 0)
            {
                velocity.x -= 5f;
            }
            if (velocity.x < 0)
            {
                velocity.x += 5f;
            }
            if (velocity.y > 0)
            {
                velocity.y -= 5f;
            }
            if (velocity.y < 0)
            {
                velocity.y += 5f;
            }
        }
        GetComponent<Rigidbody2D>().AddForce(velocity);

        if (Time.time > shotGunInterval + 0.25f)
        {
         shotgun = true;
        }

        if (Input.GetMouseButtonDown(1) && shotgun)
        {


            //another if statement, and if(Time.time > oldTime){
            //oldtime += SomePeriodInbetween)
            //if current time is longer than last time you shot + some interval

            //then you can do bullet creation
            //otherwise, don't 
            //if(Input.mousePosition.x >= 0 && Input.mousePosition.y >= 0 )
            //{
            //Get mouse position
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, bulletDistance);
            position = Camera.main.ScreenToWorldPoint(position);
            //Random.Range();
            ScreenShake ss = Camera.main.GetComponent<ScreenShake>();
            ss.shakeDuration += .01f;
            //Creating our bullet object in the world
            GameObject go1 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;
            GameObject go2 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;
            GameObject go3 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;
            GameObject go4 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;
            GameObject go5 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;
            GameObject go6 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;
            GameObject go7 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;
            GameObject go8 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;
            GameObject go9 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;
            GameObject go10 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;
            GameObject go11 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;
            GameObject go12 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;
            GameObject go13 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;
            GameObject go14 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;
            GameObject go15 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;
            GameObject go16 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;
            GameObject go17 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;
            GameObject go18 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;




            float angleR = Mathf.Atan((position.y - transform.position.y) / (position.x - transform.position.x));
            if ((position.x - transform.position.x) < 0)
                angleR += Mathf.PI;

            // this is purely to have the sprite oriented correctly...
            go1.transform.LookAt(position);
            go2.transform.LookAt(position);
            go3.transform.LookAt(position);
            go4.transform.LookAt(position);
            go5.transform.LookAt(position);
            go6.transform.LookAt(position);
            go7.transform.LookAt(position);
            go8.transform.LookAt(position);
            go9.transform.LookAt(position);
            go10.transform.LookAt(position);
            go11.transform.LookAt(position);
            go12.transform.LookAt(position);
            go13.transform.LookAt(position);
            go14.transform.LookAt(position);
            go15.transform.LookAt(position);
            go16.transform.LookAt(position);
            go17.transform.LookAt(position);
            go18.transform.LookAt(position);

            //go1.transform.Rotate(new Vector3(0, 0, Random.Range(-2, 2)));
            //go2.transform.Rotate(new Vector3(0, 0, Random.Range(-2, 2)));
            //go3.transform.Rotate(new Vector3(0, 0, Random.Range(-2, 2)));
            //go4.transform.Rotate(new Vector3(0, 0, Random.Range(-2, 2)));
            //go5.transform.Rotate(new Vector3(0, 0, Random.Range(-2, 2)));
            //go6.transform.Rotate(new Vector3(0, 0, Random.Range(-2, 2)));

            //Remove debug when not needed


            //go1.transform. = 1500;


            float vari1 = Random.Range(-variance2, variance2);
            float vari2 = Random.Range(-variance2, variance2);
            float vari3 = Random.Range(-variance2, variance2);
            float vari4 = Random.Range(-variance2, variance2);
            float vari5 = Random.Range(-variance2, variance2);
            float vari6 = Random.Range(-variance2, variance2);
            float vari7 = Random.Range(-variance2, variance2);
            float vari8 = Random.Range(-variance2, variance2);
            float vari9 = Random.Range(-variance2, variance2);
            float vari10 = Random.Range(-variance2, variance2);
            float vari11 = Random.Range(-variance2, variance2);
            float vari12 = Random.Range(-variance2, variance2);
            float vari13 = Random.Range(-variance2, variance2);
            float vari14 = Random.Range(-variance2, variance2);
            float vari15 = Random.Range(-variance2, variance2);
            float vari16 = Random.Range(-variance2, variance2);
            float vari17 = Random.Range(-variance2, variance2);
            float vari18 = Random.Range(-variance2, variance2);


            //Add forward force to the bullet
            go1.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari1), thrust2 * Mathf.Sin(angleR + vari1)));
            go2.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari2), thrust2 * Mathf.Sin(angleR + vari2)));
            go3.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari3), thrust2 * Mathf.Sin(angleR + vari3)));
            go4.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari4), thrust2 * Mathf.Sin(angleR + vari4)));
            go5.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari5), thrust2 * Mathf.Sin(angleR + vari5)));
            go6.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari6), thrust2 * Mathf.Sin(angleR + vari6)));
            go7.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari7), thrust2 * Mathf.Sin(angleR + vari7)));
            go8.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari8), thrust2 * Mathf.Sin(angleR + vari8)));
            go9.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari9), thrust2 * Mathf.Sin(angleR + vari9)));
            go10.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari10), thrust2 * Mathf.Sin(angleR + vari10)));
            go11.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari11), thrust2 * Mathf.Sin(angleR + vari11)));
            go12.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari12), thrust2 * Mathf.Sin(angleR + vari12)));
            go13.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari13), thrust2 * Mathf.Sin(angleR + vari13)));
            go14.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari14), thrust2 * Mathf.Sin(angleR + vari14)));
            go15.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari15), thrust2 * Mathf.Sin(angleR + vari15)));
            go16.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari16), thrust2 * Mathf.Sin(angleR + vari16)));
            go17.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari17), thrust2 * Mathf.Sin(angleR + vari17)));
            go18.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari18), thrust2 * Mathf.Sin(angleR + vari18)));
            //After a certain amount of seconds, destroy bullet
            Destroy(go1, 2.0f);
            Destroy(go2, 2.0f);
            Destroy(go3, 2.0f);
            Destroy(go4, 2.0f);
            Destroy(go5, 2.0f);
            Destroy(go6, 2.0f);
            Destroy(go7, 2.0f);
            Destroy(go8, 2.0f);
            Destroy(go9, 2.0f);
            Destroy(go10, 2.0f);
            Destroy(go11, 2.0f);
            Destroy(go12, 2.0f);
            Destroy(go13, 2.0f);
            Destroy(go14, 2.0f);
            Destroy(go15, 2.0f);
            Destroy(go16, 2.0f);
            Destroy(go17, 2.0f);
            Destroy(go18, 2.0f);




            //}

            shotgun = false;
            shotGunInterval = Time.time;

        }
        else if (reflectiveBulletPowerUp && powerUpInUse == false && Input.GetKey(KeyCode.B))         {
            // instatiate reflective bullet objects.
            powerUpTimer = Time.time;             powerUpInUse = true;          }         else if (reflectiveBulletPowerUp && powerUpInUse && Input.GetMouseButton(0))         {             if (Time.time > powerUpTimer + 10f)             {                 reflectiveBulletPowerUp = false;
                powerUpInUse = false;             }             Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);             position = Camera.main.ScreenToWorldPoint(position);             float vari1 = Random.Range(-variance, variance);             float angleR = Mathf.Atan((position.y - transform.position.y) / (position.x - transform.position.x));             if ((position.x - transform.position.x) < 0)                 angleR += Mathf.PI;              GameObject go1 = Instantiate(reflectiveBullet, bulletMuzzle.transform.position, bulletMuzzle.transform.rotation) as GameObject;             go1.transform.LookAt(position);             go1.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust2 * Mathf.Cos(angleR + vari1), thrust2 * Mathf.Sin(angleR + vari1)));             Destroy(go1, 3.0f);         }
        else if(blackHolePowerUp&& Input.GetKey(KeyCode.B)){

            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
            position = Camera.main.ScreenToWorldPoint(position);
            float vari1 = Random.Range(-variance, variance);
            float angleR = Mathf.Atan((position.y - transform.position.y) / (position.x - transform.position.x));
            if ((position.x - transform.position.x) < 0)
                angleR += Mathf.PI;
                
            GameObject go1 = Instantiate(blackHole, bulletMuzzle.transform.position, bulletMuzzle.transform.rotation) as GameObject;
            go1.transform.LookAt(position);

            go1.GetComponent<Rigidbody2D>().AddForce(new Vector2(blackHoleSpeed * Mathf.Cos(angleR + vari1), blackHoleSpeed * Mathf.Sin(angleR + vari1)));

            blackHolePowerUp = false;
            Destroy(go1, 15.0f);
        } 
        else if (Input.GetMouseButton(0))
        {
            
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
            position = Camera.main.ScreenToWorldPoint(position);
            float vari1 = Random.Range(-variance, variance);
            float angleR = Mathf.Atan((position.y - transform.position.y) / (position.x - transform.position.x));
            if ((position.x - transform.position.x) < 0)
                angleR += Mathf.PI;



            GameObject go1 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, bulletMuzzle.transform.rotation) as GameObject;


            go1.transform.LookAt(position);
                    
            //go1.GetComponent<Rigidbody2D>().AddForce(new Vector2(go1.transform.forward.x, go1.transform.forward.y).normalized * 1800);
                go1.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust * Mathf.Cos(angleR + vari1), thrust * Mathf.Sin(angleR + vari1)));

            Destroy(go1, 2.0f);


            //shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            //shootDirection = shootDirection - transform.position;
            //// normalize it so that no matter how far you have clicked the magnitude does not depend on the distance
            //shootDirection = shootDirection.normalized;

            //Rigidbody2D bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as Rigidbody2D;
            //bulletInstance.velocity = new Vector2(shootDirection.x * bulletSpeed, shootDirection.y * bulletSpeed);


        }



        if(Time.time > dashInterval + 4f){
            dash = true;
        }

        if(dash && Input.GetKey(KeyCode.Space))
        {
            velocityRate = 21f;
            dashInterval = Time.time;
            dash = false;

        }
        if (dashInterval + .3 < Time.time)
        {
            velocityRate = 7f;
        }


    }
}