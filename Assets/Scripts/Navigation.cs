using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Navigation : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }
    void FixedUpdate()
    {   
        agent.destination = player.transform.position;      
    }


    //trying to set different nav agents to take different paths in one script, but ultimately decided to do different scripts for the sake of ease
    //this also contains code to try and get nav agents to pause their animation when hit and pause temporarily from their path -- isnt currently working

    //     void Update()
    // {   
    //     if(agent.agentTypeID == 2){
    //         agent.destination = statue.transform.position;
    //     }
    //     else if(agent.agentTypeID == 3){
    //         agent.destination = player.transform.position;
    //     }

    // }

    //     void OnTriggerEnter(Collider other)
    // {
    //     // Check if the object has a specific tag, e.g., "StopZone"
    //     if (other.CompareTag("StopZone"))
    //     {
    //         StopAgent();
    //     }
    // }

    // void OnTriggerExit(Collider other)
    // {
    //     // Resume agent movement when it exits the trigger
    //     if (other.CompareTag("StopZone"))
    //     {
    //         ResumeAgent();
    //     }
    // }

    // void StopAgent()
    // {
    //     agent.isStopped = true;
    //     Debug.Log("Agent has stopped.");
    // }

    // void ResumeAgent()
    // {
    //     agent.isStopped = false;
    //     Debug.Log("Agent has resumed moving.");
    // }


}
