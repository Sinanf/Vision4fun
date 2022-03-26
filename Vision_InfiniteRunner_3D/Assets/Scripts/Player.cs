using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Touch touch;
    private Rigidbody playerRb;
    public float jumpForce;
    
    public float speedModifier;
    public float gravityModifier;
    
    private bool left;
    private bool right;
    private bool isOnGround = true;
    
    //Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
    


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        speedModifier = 10f;
        jumpForce = 10f;
        
    }

    
    void Update()
    {
        

        Vector3 moveRight = new Vector3(transform.position.x, transform.position.y, 2.5f);
        Vector3 moveLeft = new Vector3(transform.position.x, transform.position.y, -2.5f);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.deltaPosition.x > 50.0f)
            {
                left = true;
                right = false;
            }

            if (touch.deltaPosition.x < -50.0f)
            {
                left = false;
                right = true;
            }

            if (touch.deltaPosition.y > 50.0f && isOnGround)
            {
               
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                

            }

            if (right == true)
            {
                transform.position = Vector3.Lerp(transform.position, moveRight, speedModifier * Time.deltaTime);
            }

            if (left == true)
            {
                transform.position = Vector3.Lerp(transform.position, moveLeft, speedModifier * Time.deltaTime);
            }


           

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
