using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius = 2.0f;
    public float offset = 3.0f;
    NavMeshAgent m_Agent;
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            WanderFunc();
            Debug.Log("Path compleated, Wander call!");
        }
    }
    void WanderFunc()
    {
        // parameters: float radius, offset;
        Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
        localTarget += new Vector3(0, 0, offset);
        Vector3 worldTarget = transform.TransformPoint(localTarget);
        worldTarget.y = 0f;

        m_Agent.SetDestination(worldTarget);
    }
}
