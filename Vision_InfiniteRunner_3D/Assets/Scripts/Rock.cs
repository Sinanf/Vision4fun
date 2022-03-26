using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    public float rotateSpeed = 1;
    public AudioSource rockFX;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        rockFX.Play();
        this.gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
