using UnityEngine;

public class pausa : MonoBehaviour
{
    public GameObject menuPausa;
    public bool juegoPausado = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         menuPausa.SetActive(false);
        juegoPausado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else if(!juegoPausado)
            {
                Pausar();
            }
            else
            {
                Salir();
            }

        }
    }

    public void Reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
    }

    public void Pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
