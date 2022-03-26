using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefab;
    public GameObject rockPrefab;
    private Player playerScript;

    private float startDelayObs = 2.5f;
    private float repeatRateObs = 1.5f;

    private float startDelayRock = 1;
    private float repeatRateRock = 0.5f;

    private int yLines;
    
    

    private Vector3 spawnPos = new Vector3(35, 0, 0);
    
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelayObs, repeatRateObs);
        InvokeRepeating("SpawnRock", startDelayRock, repeatRateRock);
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        
    }

    
    void Update()
    {
       
    }

    public void SpawnObstacle()
    {
        if (playerScript.gameOver == false)
        {
            spawnPos = new Vector3(25, yLines, Random.Range(-3, 3));
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    }

    //use this to spawn rock
    public void SpawnRock()
    {
        yLines = (int)Random.Range(1.1f, 1.5f);

        if (playerScript.gameOver == false)
        {
            spawnPos = new Vector3(20, yLines, Random.Range(-3, 3));
            Instantiate(rockPrefab, spawnPos, rockPrefab.transform.rotation);
        }
    }

    



}
