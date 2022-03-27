using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public static int rockCount;
    public GameObject rockCountDisplay;
    
    public float speedModifier;
    public float gravityModifier;
    public float jumpForce;

    public int maxEnergy = 100;
    public int currentEnergy;
    public EnergyBar energyBar;

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

        energyBar.SetMaxEnergy(maxEnergy);
        currentEnergy = maxEnergy;
        

        gravityModifier = 1.5f;
        speedModifier = 10f;
        jumpForce = 500f;
        Physics.gravity *= gravityModifier;

    }

    
    void Update()
    {

        //rock count
        rockCountDisplay.GetComponent<Text>().text = "" + rockCount;

        PlayerMovement();
        
    }

    private void PlayerMovement()
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
                LoseEnergy(5);
            }

            if (touch.deltaPosition.x < -50.0f)
            {
                left = false;
                right = true;
                LoseEnergy(5);
            }

            if (touch.deltaPosition.y > 50.0f && isOnGround && !gameOver)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                playerAnim.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound, 1f);
                LoseEnergy(7);
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
            Camera.main.GetComponent<AudioSource>().Stop();


        }

                
    }

    private void OnTriggerEnter(Collider other)
    {
        rockCount += 1;
        other.gameObject.SetActive(false);
        GainEnergy(3);
    }

    private void LoseEnergy(int fatigue)
    {
        currentEnergy -= fatigue;
        energyBar.SetEnergy(currentEnergy);
    }

    private void GainEnergy(int power)
    {
        currentEnergy += power;
        energyBar.SetEnergy(currentEnergy);
    }
}
