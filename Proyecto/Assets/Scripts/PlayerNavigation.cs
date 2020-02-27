using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerNavigation : MonoBehaviour
{

    private NavMeshAgent agent;
    public GameObject[] waypoints;

    private int currWP;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.GetChild(0);

     agent = GetComponent<NavMeshAgent>();

        if (agent && waypoints.Length > 0) agent.SetDestination(waypoints[currWP].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(agent)
        {
            if(agent.remainingDistance < 0.2f)
            {
                currWP++;
                currWP %= waypoints.Length;
                agent.SetDestination(waypoints[currWP].transform.position);
            }
        }
    }
}
