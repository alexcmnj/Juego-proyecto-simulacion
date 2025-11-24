using UnityEngine;
using TMPro;

public class Scoremanager : MonoBehaviour
{
    public static Scoremanager instance;

    public int player1Score = 0;
    public int player2Score = 0;

    public TextMeshProUGUI scoreP1;
    public TextMeshProUGUI scoreP2;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        scoreP1.text = player1Score.ToString();
        scoreP2.text = player2Score.ToString();
    }

    public void AddGoalP1()
    {
        player1Score++;
        scoreP1.text = player1Score.ToString();
    }

    public void AddGoalP2()
    {
        player2Score++;
        scoreP2.text = player2Score.ToString();
    }
}