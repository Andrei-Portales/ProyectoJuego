using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    private Animator anim;
    private bool vivo;
    private UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        vivo = true;
        agent = GetComponent<NavMeshAgent>();
        playerTransform = player.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (vivo)
        {
            agent.destination = playerTransform.position;
            anim.SetFloat("Speed", agent.velocity.magnitude / agent.speed);

        }
          
    }

    
}
