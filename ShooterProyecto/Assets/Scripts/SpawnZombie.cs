using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{

    public GameObject personaje;
    public GameObject zombie;
    private float tiempo;
    private float timpoEsperado;

    

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
            timpoEsperado += 6;
        }

       
    }

    
}
