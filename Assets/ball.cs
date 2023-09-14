using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
    Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public float speed;
    public Vector2 direction;
    public scoreScript tomScore;
    public scoreScript jerryScore;
    private bool isWaiting = false;
    private bool isGameOver = false; 
    public AudioSource boingSound;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.one.normalized;
        tomScore = FindObjectOfType<scoreScript>();
        jerryScore = FindObjectOfType<scoreScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boingSound = GetComponent<AudioSource>();
    }

    void Update() {
        if (!isWaiting && !isGameOver) { 
            rb.velocity = direction * speed;
        }
    }

    // on collision
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject != null) {
            if (collision.gameObject.CompareTag("jerry") || collision.gameObject.CompareTag("tom")) {
            direction.x = -direction.x;
            boingSound.Play();

            } else if (collision.gameObject.CompareTag("top")) {
                direction.y = -direction.y;

            } else if (collision.gameObject.CompareTag("bottom")) {
                direction.y = -direction.y;
            }

            if (collision.gameObject.CompareTag("jerrySideWall")) {
                tomScore.updateTom(1);
                ResetBall();

            } else if (collision.gameObject.CompareTag("tomSideWall")) {
                jerryScore.updateJerry(1);
                ResetBall();  
            }
        }
    }

    // reset ball method
    void ResetBall() {
        isWaiting = true;
        rb.velocity = Vector2.zero;
        direction.x = -direction.x;
        rb.gravityScale = 0; // Disable gravity
        transform.position = new Vector3(0f, 0f, 0f);
        StartCoroutine(StartMovingAfterDelay(2f)); // wait for 2 seconds before moving again.
    }

    // delay ball movement method, gravity = 0
    IEnumerator StartMovingAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        isWaiting = false;
        rb.gravityScale = 1; // restore gravity
    }

    public void SetGameOverState(bool gameOver) {
        isGameOver = gameOver;
        if (gameOver) {
            rb.velocity = Vector2.zero;
            gameObject.SetActive(false); // disable the ball
        }
    }
}