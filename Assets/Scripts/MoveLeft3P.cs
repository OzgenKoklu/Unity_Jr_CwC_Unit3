using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft3P : MonoBehaviour
{
    private float speed = 20;
    private int leftBoundary = -15; 
    private PlayerControllerUnit3P playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerUnit3P>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        } 
        
        if (transform.position.x < leftBoundary && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
