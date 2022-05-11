using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager3P : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private int spawnDelay = 3;
    private int repeatRate = 2;
    private PlayerControllerUnit3P playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerControllerUnit3P>();
        startSpawn();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnObstacle ()
    {
        
        if(playerController.gameOver == false)
        {
            int i = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[i], spawnPosition, obstaclePrefabs[i].transform.rotation);
        }
       
    }

    void startSpawn()
    {
        InvokeRepeating("spawnObstacle", spawnDelay, repeatRate);
    }

}
