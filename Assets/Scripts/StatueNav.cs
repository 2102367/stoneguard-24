using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class StatueNav : MonoBehaviour
{
    public GameObject statue;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        statue = GameObject.Find("Statue");
    }

    void FixedUpdate()
    {   
        agent.destination = statue.transform.position;      
    }

}
