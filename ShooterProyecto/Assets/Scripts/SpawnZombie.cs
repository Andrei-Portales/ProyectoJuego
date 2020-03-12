using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnZombie : MonoBehaviour
{

    public GameObject personaje;
    public GameObject zombie;
    private float tiempo;
    private float timpoEsperado;
    public Slider slider;

    

    // Start is called before the first frame update
    void Start()
    {
        tiempo = 0;
        timpoEsperado = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo >= timpoEsperado)
        {
            GameObject tempZombie = Instantiate(zombie,gameObject.transform.position, Quaternion.identity);
            tempZombie.GetComponent<Target>().setPersonaje(personaje);
            tempZombie.GetComponent<Target>().setSlider(slider);
            timpoEsperado += 6;
        }

       
    }

    
}
