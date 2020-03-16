using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public static bool Pausado = false;
    public GameObject isPaused;

    private void Start()
    {
        isPaused.SetActive(false);
        Pausado = false;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausado)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }

    }


    public void Continuar()
    {
        isPaused.SetActive(false);
        Time.timeScale = 1.0f;
        Pausado = false;
    }

    public void Pausar()
    {
        isPaused.SetActive(true);
        Time.timeScale = 0.0f;
        Pausado = true;
    }

    public void MenuPrincipal()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Reiniciar()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
}
