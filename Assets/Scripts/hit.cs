using System.Collections;
using UnityEngine;

public class hit : MonoBehaviour
{
    public float hitForce = 3f;
    public float hitDistance = 0.2f;

    public Transform hitPoint;   // Punto de golpe
    public bool isPlayer1 = true; // Player1 = Space, Player2 = L

    private Animator anim;
   
    void Start()
    {
        
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isPlayer1==true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("hit",true);
                StartCoroutine(Resethit());
                TryHitBall();
                
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                isPlayer1 = false;
                anim.SetBool("hit",true);
                StartCoroutine(Resethit());
                TryHitBall();
                
            }

        }
    }

    void TryHitBall()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(hitPoint.position, hitDistance);

        foreach (Collider2D h in hits)
        {
            if (h.CompareTag("Ball"))
            {
                Rigidbody2D rb = h.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 dir = (h.transform.position - hitPoint.position).normalized;
                    rb.AddForce(dir * hitForce, ForceMode2D.Impulse);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (hitPoint != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(hitPoint.position, hitDistance);
        }
    }

    IEnumerator Resethit()
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("hit", false);
    }
}