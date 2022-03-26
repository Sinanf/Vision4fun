using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    
    public float rotateSpeed = 1;
   


    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    

    private void OnCollisionEnter(Collision collision)
    {

        
    }

    


}
