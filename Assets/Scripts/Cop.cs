using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cop : MonoBehaviour
{

    NavMeshAgent agent;
    void OnEnable()
    {
        Wallet.OnShout += Seek;
    }
    void OnDisable()
    {
        Wallet.OnShout -= Seek;
    }

    void Seek(GameObject target)
    {
        agent.SetDestination(target.transform.position);
    }
}
