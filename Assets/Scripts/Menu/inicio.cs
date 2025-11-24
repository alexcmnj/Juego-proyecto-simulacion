using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inicio : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void salir()
    {
        Debug.Log("Salir Del Juego");
        Application.Quit();
    }
}