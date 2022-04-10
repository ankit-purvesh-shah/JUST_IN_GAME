using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AddPlayerControlledVelocity : MonoBehaviour
{
    [SerializeField]
    KeyCode keyPositive;

    [SerializeField]
    KeyCode keyNegative;

    [SerializeField]
    Vector3 v3Force;

    [SerializeField]
    private float jumpForce = 10;

    private bool onPlatform;
    private string PLATFORM_TAG = "Platform";

    private Rigidbody myBody;



    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();
        //PlayerJump();
    }
    
    private void Update()
    {
        PlayerJump();
        Vector3 velocity = myBody.velocity;
        if (onPlatform)
        {
            myBody.velocity = velocity;
        }
        else
        {
            myBody.velocity = velocity / 1.005f;
        }
    }
  
    void PlayerMove()
    {

        if (Input.GetKey(keyPositive))
        {
            myBody.velocity += v3Force;
        }

        if (Input.GetKey(keyNegative))
        {
            myBody.velocity -= v3Force;
        }
    }


    void PlayerJump()
    {
        // Input.GetButtonDown function works only when the button is being pressed down.
        // Also here we check if the Player is on Ground or not
        if (Input.GetButtonDown("Jump") && onPlatform)
        {
            Vector3 velocity = myBody.velocity;
            velocity.y = jumpForce;
            myBody.velocity = velocity * 0.3f;
            //myBody.AddForce(new Vector3(0f, jumpForce), ForceMode.Impulse);
            //myBody.AddForce(Vector3.up * jumpForce, ForceMode.Acceleration);
            onPlatform = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(PLATFORM_TAG))
        {
            onPlatform = true;
            Vector3 velocity = myBody.velocity;
            //velocity.y = -0.5f;
            myBody.velocity = velocity;
        }
    }



}


