using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public float startTime = 120f; // 2 minutos
    private float timeLeft;
    Scoremanager scoremanager;
    private bool goldeoro=false;

    public TMP_Text timerText;

    void Start()
    {
        scoremanager=Scoremanager.instance;
        timeLeft = startTime;
    }
    
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
            timeLeft = 0;

        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        int seconds = Mathf.FloorToInt(timeLeft % 120f);

        timerText.text = $"{seconds:000}";

        if (timeLeft == 0)
        {
            if (scoremanager.player1Score == 0 && scoremanager.player2Score == 0)
            {
                Goldeoro();
                if(scoremanager.player1Score>scoremanager.player2Score)
                {
                    Debug.Log("Jugador 1 gana en gol de oro!");
                    if (GameManager.instance != null)
                    {
                        GameManager.instance.GameOver();
                    }
                }
                else if(scoremanager.player2Score>scoremanager.player1Score)
                {
                    Debug.Log("Jugador 2 gana en gol de oro!");
                    if (GameManager.instance != null)
                    {
                        GameManager.instance.GameOver();
                    }
                }
            }
            else
            {
                Debug.Log("Tiempo terminado!");
                if (GameManager.instance != null)
                {
                    GameManager.instance.GameOver();
                }
            }
        }

        void Goldeoro()
        {
            goldeoro = true;
            timeLeft = 60;
            Debug.Log("Gol de oro! Tiempo extra de 1 minuto!");
        }
    }
}