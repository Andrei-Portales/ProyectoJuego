using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{


    public GameObject musicaFondo;
    // Start is called before the first frame update


    void Start()
    {
        Instantiate(musicaFondo);
    }


    public void StartGame()
    {
        
        MenuPausa.gameIsPause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Juego");
    }
}
