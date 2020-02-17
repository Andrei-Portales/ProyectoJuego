using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disparo : MonoBehaviour
{

    public Camera camara;
    public GameObject sonidoDisparo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!MenuPausa.gameIsPause)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                shoot();
                Instantiate(sonidoDisparo);
            }
        }
    }

    private void shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit , 100f))
        {
            if (hit.transform.tag.Equals("Zombie"))
            {
                Destroy(hit.transform.gameObject);
            }
            
        }
    }
}
