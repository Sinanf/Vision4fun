using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefab;
    public GameObject rockPrefab;
    private Player playerScript;

    private float startDelayObs = 2;
    private float repeatRateObs = 2;

    private float startDelayRock = 1;
    private float repeatRateRock = 0.5f;

    private int xLines = 30;
    private int yLines = (int)1.25;
    private int[] spawnLinesZ = { -3, 0, 3 };
    

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
            Instantiate(obstaclePrefab, SpawningPos(), obstaclePrefab.transform.rotation);
        }
        
    }

    //use this to spawn rock
    public void SpawnRock()
    {
        if (playerScript.gameOver == false)
        {
            Instantiate(rockPrefab, SpawningPos(), rockPrefab.transform.rotation);
        }
    }

    public Vector3 SpawningPos()
    {
        
        return spawnPos = new Vector3(xLines, yLines, Random.Range(-3,3));
                    
    }



}
