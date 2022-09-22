using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RobberController : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();    
    }

    void Update()
    {
        Seek();
    }

    private void Seek()
    {
        agent.destination = target.transform.position;
    }
}
