using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft3P : MonoBehaviour
{
    private float speed = 20;
    private int leftBoundary = -15; 
    private PlayerControllerUnit3P playerControllerScript;
    private Transform playerTransform;
    private float playerStartbound = -1.45f;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerUnit3P>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
        DestroyOutOfBounds();
    }


    private void MoveLeft()
    {
        if (playerControllerScript.gameOver == false && playerTransform.position.x > playerStartbound)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * playerControllerScript.speedModifier);
        }
    }

    private void DestroyOutOfBounds()
    {
        if (transform.position.x < leftBoundary && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
