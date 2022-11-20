using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.AI;
public class HideAgent : MonoBehaviour
{
    public GameObject[] hidingSpots;
    public GameObject target;
    public NavMeshAgent meshAgent;
    public GameObject hideSpot;
    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();

        if (!meshAgent)
        {
            meshAgent = gameObject.AddComponent<NavMeshAgent>();
        }

        hidingSpots = GameObject.FindGameObjectsWithTag("hide");
    }

    private void Update()
    {
        
    }

    public void UpdateHide()
    {
        Hide();
    }

    void Hide()
    {
        if (meshAgent == null) return;

        (float, GameObject) farFromTarget = hidingSpots.Select(
            ho => (Vector3.Distance(ho.transform.position, target.transform.position), ho)
            ).Max();
        hideSpot = farFromTarget.Item2;
        meshAgent.SetDestination(farFromTarget.Item2.transform.position);
    }
}