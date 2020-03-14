using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    private float health;
    private bool esEnemigoMuerto;

    private GameObject Personaje;
    private NavMeshAgent agent;
    private Animator anim;

    public GameObject PrefabsonidoZombie;
    private GameObject sonidoInstance;
    public Slider healthBar;

    public void setPersonaje(GameObject per)
    {
        Personaje = per;
    }

    void Start()
    {

        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        anim.SetBool("isLive", true);
        health = 100f;
        esEnemigoMuerto = false;
        agent.speed = 2.5f;
       
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
           
            
            Destroy(sonidoInstance);
            
            Destroy(gameObject, 10);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
//            other.gameObject.GetComponent<Player>().damage();
        }
    }


    public void setSlider(Slider slider)
    {
        healthBar = slider;
    }

    public void TakeDamage(float amount)
    {
        if (!esEnemigoMuerto)
        {
            health -= amount;
            healthBar.value = health / 100f;
        }

    }


   


}
