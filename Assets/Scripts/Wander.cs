using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius = 5.0f;
    public Vector3 offset = new Vector3(0, 0, 0);
    public Vector3 worldTarget;
    NavMeshAgent m_Agent;
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();

        if (!m_Agent)
        {
            m_Agent = gameObject.AddComponent<NavMeshAgent>();
        }
    }

    public void SetWanderRadius(float rad)
    {
        radius = rad;
    }

    // Update is called once per frame
    public void UpdateWander()
    {
        if (!m_Agent) return;

        if (!m_Agent.pathPending && !m_Agent.hasPath)
        {
            WanderFunc();
        }
    }
    void WanderFunc()
    {
        // parameters: float radius, offset;
        //Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
        //localTarget += offset;
        //worldTarget = transform.TransformPoint(localTarget);
        //worldTarget.y = 0f;
        worldTarget = NavUtils.RandomNavSphere(transform.position, radius, -1);

        m_Agent.SetDestination(worldTarget);
    }
}
