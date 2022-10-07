using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(LineRenderer))]
public class PathDebugger : MonoBehaviour
{
    public NavMeshAgent agent;
    private LineRenderer m_Linerenderer;
    void Start()
    {
        m_Linerenderer = GetComponent<LineRenderer>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.hasPath)
        {
            m_Linerenderer.positionCount = agent.path.corners.Length;
            m_Linerenderer.SetPositions(agent.path.corners);
            m_Linerenderer.enabled = true;
        }
        else
        {
            m_Linerenderer.enabled = false;

        }
    }
}
