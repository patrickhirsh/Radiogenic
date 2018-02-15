using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerSynthControls : MonoBehaviour
{

    private Vector2 velocity;
    public float velocityRate = 20f;
    public float accelerationRate;
    Rigidbody2D rb = new Rigidbody2D();

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
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




        }
    }