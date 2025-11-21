using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playerScore = 0;
    public int player2Score = 0;

    public Text scoreText;
    public Text timerText;

    public float matchTime = 120f;

    void Update()
    {
        matchTime -= Time.deltaTime;
        if (matchTime < 0)
        {
            matchTime = 0;
            Debug.Log("Match Over!");
        }
        int m = Mathf.FloorToInt(matchTime / 60);
        int s = Mathf.FloorToInt(matchTime % 60);

        timerText.text = $"{m:00}:{s:00}";
        scoreText.text = playerScore + " - " + player2Score;
    }
}
