using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool gameIsPause;
    public GameObject panelPausa;
    public GameObject[] Puntero;
   

    // Start is called before the first frame update
    void Start()
    {
        gameIsPause = false;
        panelPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            pause();
    }


    public void returnMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
    }


    private void pause()
    {
        if (!gameIsPause)
        {
            panelPausa.SetActive(true);
            gameIsPause = true;
            Time.timeScale = 0f;

            foreach(GameObject g in Puntero)
            {
                g.SetActive(false);
            }
        }
        else
        {
            reanudar();
        }
    }

    public void reanudar()
    {
        panelPausa.SetActive(false);
        gameIsPause = false;
        Time.timeScale = 1f;
        foreach (GameObject g in Puntero)
        {
            g.SetActive(true);
        }
    }

    public void reiniciar()
    {
        Time.timeScale = 1f;
        foreach (GameObject g in Puntero)
        {
            g.SetActive(true);
        }
        SceneManager.LoadScene(1);
    }

}
