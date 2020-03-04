using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    public Slider healthBar;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(GameObject.FindGameObjectWithTag("Zombie"))
        {
            healthBar.value += 0.20f;
        }
    }
}
