using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBackGroundMovement : MonoBehaviour
{
    private float speed = 30f;
    private Player playerScript;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }


    void Update()
    {

        if (playerScript.gameOver == false)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}
