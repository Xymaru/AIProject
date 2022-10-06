using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SeekController : MonoBehaviour
{
    [Header("Seek parameters")]
    [SerializeField] private GameObject target;
    [SerializeField] private float timeToVel = 2.0f;
    [SerializeField] private float speedSmothing = 0.1f;
    [SerializeField, Range(0f, 5f)] private float maxSpeed = 5f;

    float currentTime = 0.0f;
    NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Random.Range(4.0f, maxSpeed);
    }

    void Update()
    {
        Seek();
    }

    private void Seek()
    {
        agent.destination = target.transform.position;
        if(currentTime > timeToVel)
        {
            agent.speed = Random.Range(agent.speed - speedSmothing, maxSpeed);
            currentTime = 0;
        }
        currentTime += Time.deltaTime;
    }
}
