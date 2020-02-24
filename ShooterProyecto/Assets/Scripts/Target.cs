﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    private float health;
    private bool esEnemigoMuerto;

    public GameObject Personaje;
    private NavMeshAgent agent;
    private Animator anim;

    public GameObject PrefabsonidoZombie;
    private GameObject sonidoInstance;
   
   

    void Start()
    {

        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        anim.SetBool("isLive", true);
        health = 100f;
        esEnemigoMuerto = false;
        agent.speed = 2.5f;
        sonidoInstance = Instantiate(PrefabsonidoZombie);
    }

    void Update()
    {
        if (!esEnemigoMuerto)
        {
            anim.SetFloat("Speed",agent.speed);
            agent.SetDestination(Personaje.transform.position);
        }
       
        if (health <= 0)
        {
            
            agent.speed = 0f;
            anim.SetBool("isLive", false);
            GetComponent<CapsuleCollider>().radius = 2f;
            
            if (sonidoInstance)
            {
                Destroy(sonidoInstance);
                Destroy(gameObject, 10);
            }
               


           

        }

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.tag);
    }

    public void TakeDamage(float amount)
    {
        if (!esEnemigoMuerto)
        {
            health -= amount;
            //healthBar.fillAmount = health / 100f;
        }

    }


   


}
