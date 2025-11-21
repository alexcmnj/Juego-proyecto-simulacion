using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    GameManager gm;
    Vector2 startPos;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("GoalP1"))
        {

            gm.player2Score++;
            resetBall();
        }
        else if (collision.CompareTag("GoalP2"))
        {
            gm.playerScore++;
            resetBall();
        }
    }

    void resetBall()
    {
        transform.position = startPos;
        rb.angularVelocity = 0;
        rb.linearVelocity = Vector2.zero;
    }
}
