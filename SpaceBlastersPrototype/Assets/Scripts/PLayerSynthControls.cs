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
    float bulletDistance = 1f;
    public GameObject bulletPrefab;
    float interval = 0;
    bool shotgun = false;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bulletPrefab = (GameObject)Resources.Load("bullet");
    }

    private void Rotate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);


        velocity.x = 0;
        velocity.y = 0;
        //		velocity.x = Input.GetAxis("Horizontal") * velocityRate;
        //		velocity.y = Input.GetAxis("Vertical") * velocityRate;
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

        if (Time.time > interval + 1f)
            shotgun = true;

        if (Input.GetMouseButtonDown(0) && shotgun)
        {
            
            
            //another if statement, and if(Time.time > oldTime){
            //oldtime += SomePeriodInbetween)
            //if current time is longer than last time you shot + some interval
           
            //then you can do bullet creation
            //otherwise, don't 
            if(Input.mousePosition.x >= 0 && Input.mousePosition.y >= 0 )
            {
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


               

                //setting the bullet objects direction to be twowards the mouse position
                go1.transform.LookAt(position + new Vector3(Random.Range(-2,2), Random.Range(-2,2)));
                go2.transform.LookAt(position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2)));
                go3.transform.LookAt(position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2)));
                go4.transform.LookAt(position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2)));
                go5.transform.LookAt(position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2)));
                go6.transform.LookAt(position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2)));

                //Remove debug when not needed
                Debug.Log(position);
                //Add forward force to the bullet
                go1.GetComponent<Rigidbody2D>().AddForce(go1.transform.forward * 1500);
                go2.GetComponent<Rigidbody2D>().AddForce(go2.transform.forward * 1500);
                go3.GetComponent<Rigidbody2D>().AddForce(go3.transform.forward * 1500);
                go4.GetComponent<Rigidbody2D>().AddForce(go4.transform.forward * 1500);
                go5.GetComponent<Rigidbody2D>().AddForce(go5.transform.forward * 1500);
                go6.GetComponent<Rigidbody2D>().AddForce(go6.transform.forward * 1500);

                //After a certain amount of seconds, destroy bullet
                Destroy(go1, 1.0f);
                Destroy(go2, 1.0f);
                Destroy(go3, 1.0f);
                Destroy(go4, 1.0f);
                Destroy(go5, 1.0f);
                Destroy(go6, 1.0f);

               

  
            }
           
            shotgun = false;
            interval = Time.time;
           
        }
        else if (Input.GetMouseButton(0))
        {
            
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, bulletDistance);
            position = Camera.main.ScreenToWorldPoint(position);

          

                GameObject go1 = Instantiate(bulletPrefab, bulletMuzzle.transform.position, Quaternion.identity) as GameObject;
            go1.transform.LookAt(position + new Vector3(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f)));
                go1.GetComponent<Rigidbody2D>().AddForce(go1.transform.forward * 1500);
                Destroy(go1, 1.0f);



        }





        }
    }