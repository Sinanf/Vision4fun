using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefab;
    private Player playerScript;

    private float startDelay = 2;
    private float repeatRate = 2;

    private Vector3 spawnPos = new Vector3(35, 0, 0);
    
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    }
}
