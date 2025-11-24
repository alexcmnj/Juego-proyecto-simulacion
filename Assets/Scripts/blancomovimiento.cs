using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blancomovimiento : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public Vector2 startPos;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        transform.position = startPos;
        transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Horizontal = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Horizontal = 1;
        }

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", Horizontal != 0.0f);

        // Detectar Suelo
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.25f))
        {
            Grounded = true;
        }
        else Grounded = false;

        //Animator.SetBool("falling", !Grounded && Rigidbody2D.linearVelocity.y < 0);


        // Salto
        Animator.SetBool("jump", !Grounded);
        if (Input.GetKeyDown(KeyCode.UpArrow) && Grounded)
        {
            Jump();
        }
    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = new Vector2(Horizontal, Rigidbody2D.linearVelocity.y);
    }
}
