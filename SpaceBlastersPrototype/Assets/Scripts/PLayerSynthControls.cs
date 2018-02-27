using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerSynthControls : MonoBehaviour
{
    public GameObject bulletMuzzle;
    private Vector2 velocity;
    public float velocityRate = 20f;
    public float accelerationRate;
    Rigidbody2D rb = new Rigidbody2D();
    float bulletDistance = .1f;
    public GameObject bulletPrefab;
    float interval = 0;
    bool shotgun = false;
    public int thrust = 1000;
    public float variance = 0.2f;
    public int hp = 10;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bulletPrefab = (GameObject)Resources.Load("bullet");
    }

    private void Rotate()
    {

    }

    void Hit(){
        hp--;
        if(hp <= 0)
        {
           Application.Quit();
           Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy"){
            Hit();
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

            if (Input.GetKey(KeyCode.D))             {                 velocity.x = 10f * velocityRate;             }             else if (Input.GetKey(KeyCode.A))             {                 velocity.x = -10f * velocityRate;             }             else             {                 if (velocity.x > 0)                 {                     velocity.x -= 5f;                 }                 else if (velocity.x < 0)                 {                     velocity.x += 5f;                 }             } 
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
            Debug.Log("A");
            velocity.x = -10f * velocityRate;
            if (Input.GetKey(KeyCode.W))             {                 velocity.y = 10f * velocityRate;             }             else if (Input.GetKey(KeyCode.S))             {                 velocity.y = -10f * velocityRate;             }             else             {                 if (velocity.y > 0)                 {                     velocity.y -= 5f;                 }                 else if (velocity.x < 0)                 {                     velocity.y += 5f;                 }             }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            velocity.y = -10f * velocityRate;

            if (Input.GetKey(KeyCode.D))             {                 velocity.x = 10f * velocityRate;             }             else if (Input.GetKey(KeyCode.A))             {                 velocity.x = -10f * velocityRate;             }             else             {                 if (velocity.x > 0)                 {                     velocity.x -= 5f;                 }                 else if (velocity.x < 0)                 {                     velocity.x += 5f;                 }             } 
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

            if (Input.GetKey(KeyCode.W))             {                 velocity.y = 10f * velocityRate;             }             else if (Input.GetKey(KeyCode.S))             {                 velocity.y = -10f * velocityRate;             }             else             {                 if (velocity.y > 0)                 {                     velocity.y -= 5f;                 }                 else if (velocity.x < 0)                 {                     velocity.y += 5f;                 }             }
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

        if (Time.time > interval + 0.5f)
        {
         shotgun = true;
        }

        if (Input.GetMouseButtonDown(0) && shotgun)
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

            //go1.transform.Rotate(new Vector3(0, 0, Random.Range(-2, 2)));
            //go2.transform.Rotate(new Vector3(0, 0, Random.Range(-2, 2)));
            //go3.transform.Rotate(new Vector3(0, 0, Random.Range(-2, 2)));
            //go4.transform.Rotate(new Vector3(0, 0, Random.Range(-2, 2)));
            //go5.transform.Rotate(new Vector3(0, 0, Random.Range(-2, 2)));
            //go6.transform.Rotate(new Vector3(0, 0, Random.Range(-2, 2)));

            //Remove debug when not needed
            Debug.Log(position);


            //go1.transform. = 1500;


            float vari1 = Random.Range(-variance, variance);
            float vari2 = Random.Range(-variance, variance);
            float vari3 = Random.Range(-variance, variance);
            float vari4 = Random.Range(-variance, variance);
            float vari5 = Random.Range(-variance, variance);
            float vari6 = Random.Range(-variance, variance);
            float vari7 = Random.Range(-variance, variance);
            float vari8 = Random.Range(-variance, variance);
            float vari9 = Random.Range(-variance, variance);
            float vari10 = Random.Range(-variance, variance);
            float vari11 = Random.Range(-variance, variance);
            float vari12 = Random.Range(-variance, variance);

            //Add forward force to the bullet
            go1.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust * Mathf.Cos(angleR + vari1), thrust * Mathf.Sin(angleR + vari1)));
            go2.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust * Mathf.Cos(angleR + vari2), thrust * Mathf.Sin(angleR + vari2)));
            go3.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust * Mathf.Cos(angleR + vari3), thrust * Mathf.Sin(angleR + vari3)));
            go4.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust * Mathf.Cos(angleR + vari4), thrust * Mathf.Sin(angleR + vari4)));
            go5.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust * Mathf.Cos(angleR + vari5), thrust * Mathf.Sin(angleR + vari5)));
            go6.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust * Mathf.Cos(angleR + vari6), thrust * Mathf.Sin(angleR + vari6)));
            go7.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust * Mathf.Cos(angleR + vari7), thrust * Mathf.Sin(angleR + vari7)));
            go8.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust * Mathf.Cos(angleR + vari8), thrust * Mathf.Sin(angleR + vari8)));
            go9.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust * Mathf.Cos(angleR + vari9), thrust * Mathf.Sin(angleR + vari9)));
            go10.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust * Mathf.Cos(angleR + vari10), thrust * Mathf.Sin(angleR + vari10)));
            go11.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust * Mathf.Cos(angleR + vari11), thrust * Mathf.Sin(angleR + vari11)));
            go12.GetComponent<Rigidbody2D>().AddForce(new Vector2(thrust * Mathf.Cos(angleR + vari12), thrust * Mathf.Sin(angleR + vari12)));
            //After a certain amount of seconds, destroy bullet
            Destroy(go1, 1.0f);
            Destroy(go2, 1.0f);
            Destroy(go3, 1.0f);
            Destroy(go4, 1.0f);
            Destroy(go5, 1.0f);
            Destroy(go6, 1.0f);
            Destroy(go7, 1.0f);
            Destroy(go8, 1.0f);
            Destroy(go9, 1.0f);
            Destroy(go10, 1.0f);
            Destroy(go11, 1.0f);
            Destroy(go12, 1.0f);




            //}

            shotgun = false;
            interval = Time.time;

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

            Destroy(go1, 1.0f);


            //shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            //shootDirection = shootDirection - transform.position;
            //// normalize it so that no matter how far you have clicked the magnitude does not depend on the distance
            //shootDirection = shootDirection.normalized;

            //Rigidbody2D bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as Rigidbody2D;
            //bulletInstance.velocity = new Vector2(shootDirection.x * bulletSpeed, shootDirection.y * bulletSpeed);


        }





    }
}