using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager3P : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private int spawnDelay = 2;
    private PlayerControllerUnit3P playerController;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObstacle", spawnDelay, Random.Range(1.5f,4.1f));
        playerController = GameObject.Find("Player").GetComponent<PlayerControllerUnit3P>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnObstacle ()
    {
        if(playerController.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
       
    }
}
