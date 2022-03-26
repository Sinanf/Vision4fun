using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Touch touch;
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioSource playerAudio;


    public float speedModifier;
    public float gravityModifier;
    public float jumpForce;

    private bool left;
    private bool right;
    private bool isOnGround = true;
    public bool gameOver;

    
    
    //Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
    


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        gravityModifier = 1.5f;
        speedModifier = 10f;
        jumpForce = 500f;
        Physics.gravity *= gravityModifier;

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

            if (touch.deltaPosition.y > 50.0f && isOnGround && !gameOver)
            {
               
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                playerAnim.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound, 1f);
                               

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

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("Deathtype_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1f);
        }
    }
}
