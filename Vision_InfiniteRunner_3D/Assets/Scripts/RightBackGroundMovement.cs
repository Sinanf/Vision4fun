using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBackGroundMovement : MonoBehaviour
{
    private float speed = 30f;

    void Start()
    {

    }


    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
