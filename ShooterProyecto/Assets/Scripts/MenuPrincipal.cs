using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{

    public GameObject musicaFondo;
    public GameObject loadScreen;
    public Slider slider;
    public Text progresoText;
    
    void Start()
    {
        Instantiate(musicaFondo);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; 
    }


    public void StartGame(int scene)
    {
        
        MenuPausa.gameIsPause = false;
        Time.timeScale = 1f;
        //SceneManager.LoadScene("Juego");
        StartCoroutine(Sincronizador(scene));
    }


    public void Load(int scene)
    {
        
    }

    IEnumerator Sincronizador(int scene)
    {
        AsyncOperation operacion = SceneManager.LoadSceneAsync(scene);

        loadScreen.SetActive(true);

        while (!operacion.isDone)
        {
            float progreso = Mathf.Clamp01(operacion.progress / 0.9f);

            slider.value = progreso;
            progresoText.text = progreso * 100f + "%";

            yield return null;
        }
    }
}
