using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    GameManager gm;
    Vector2 startPos;
    Rigidbody2D rb;
    public blancomovimiento player1;
    public mangomovimiento player2;

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


            Scoremanager.instance.AddGoalP1();
            StartCoroutine(ResetAfterDelay());
        }
        else if (collision.CompareTag("GoalP2"))
        {

            Scoremanager.instance.AddGoalP2();
            StartCoroutine(ResetAfterDelay());
        }
    }
    IEnumerator ResetAfterDelay()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.gravityScale = 0;

        yield return new WaitForSeconds(1f);

        player1.transform.position = player1.startPos;
        player2.transform.position = player2.startPos;

        transform.position = startPos;
        rb.gravityScale = 1;
    }
}