using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float healt;
    public Slider healthBar;
    public GameObject menuMuerte;

    private void Start()
    {
        healt = 0f;
    }


    private void Update()
    {
        if (healt >= 1)
        {
            Time.timeScale = 0f;
        }
    }


    public void damage()
    {
        healthBar.value += 0.10f;
        healt += 0.10f;
    }


}
