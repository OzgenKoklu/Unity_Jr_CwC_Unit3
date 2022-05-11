using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerUnit3P : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudioSource;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10;
    public float gravityModifier = 1;
    public bool isOnGround = true;
    public bool gameOver = false;
    public bool canJump = false;
    private int jumpCounter = 0;
    public float speedModifier = 1;
    public int playerScore = 0;
    private Vector3 actualStartPos = new Vector3(-9, 0, 0);
    private Vector3 gameStartPos = new Vector3(-1.44f, 0, 0);
    public int interPolationFramesCount = 30;
    int elapsedFrames = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        transform.position = actualStartPos;
    }

    // Update is called once per frame
    void Update()
    {
        getToStartPos();
        checkScoreMultiplier();

        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && (isOnGround || doubleJumpChecker()))
        {
            Jump();
        }

        updateScore();
    }

    private void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        playerAnim.SetTrigger("Jump_trig");
        dirtParticle.Stop();
        playerAudioSource.PlayOneShot(jumpSound, 1.0f);
        jumpCounter++;

    }

    private bool doubleJumpChecker()
    {
        if (jumpCounter < 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void updateScore()
    {
        Debug.Log(playerScore);
    }

    private void getToStartPos()
    {
        if (transform.position.x < -1.44f)
        {
            float lerpInterpolationRatio = (float)elapsedFrames / interPolationFramesCount;

            transform.position = Vector3.Lerp(actualStartPos, gameStartPos, lerpInterpolationRatio);

            elapsedFrames = (elapsedFrames + 1) % (interPolationFramesCount + 1);

        }

    }

    private void checkScoreMultiplier()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerAnim.speed = 2.0f;
            speedModifier = 2;
        }
        else
        {
            playerAnim.speed = 1;
            speedModifier = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle") && speedModifier == 1)
        {
            playerScore += 1;
        }
        else if (other.gameObject.CompareTag("Obstacle") && speedModifier == 2)
        {
            playerScore += 2;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumpCounter = 0;
            dirtParticle.Play();
            if (gameOver)
            {
                dirtParticle.Stop();
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudioSource.PlayOneShot(crashSound, 1.0f);
        }
    }
}
