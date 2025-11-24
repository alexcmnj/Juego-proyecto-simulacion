using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject GameOverPanel;
    public TextMeshProUGUI gameover;
    public Button restartButton;
    public Button menuButton;
    public pausa pausaScript;

    private bool isGameOver = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (GameOverPanel != null)
        {
            GameOverPanel.SetActive(false);
        }

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(ReiniciarEscena);
        }
        
        if (menuButton != null)
        {
            menuButton.onClick.AddListener(IrAlmenu);
        }
    }
    void Update()
    {
        if (isGameOver)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                ReiniciarEscena();
            }
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.M)) 
            {
                IrAlmenu();
            }
        }
    }

    public void GameOver()
    {

        isGameOver = true;
        if(pausaScript != null)
        {
            pausaScript.juegoPausado = false;
        }
        if (GameOverPanel != null)
        {
            GameOverPanel.SetActive(true);
        }
        if (gameover!= null)
        {
            gameover.text = "R - Reiniciar   ESC-Menú principal";
        }
    }

    public void ReiniciarEscena()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void IrAlmenu()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
