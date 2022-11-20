using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus

namespace BBUnity.Actions
{
    [Action("MyActions/Hide")]
    [Help("Get the Vector3 for hiding.")]
    public class HideBB : GOAction
    {
        HideAgent m_HideAgent;

        [InParam("Cop")]
        [Help("Seeker to hide from")]
        public GameObject cop;

        public override void OnStart()
        {
            Debug.Log(cop);
            m_HideAgent = gameObject.GetComponent<HideAgent>();
            if (!m_HideAgent)
            {
                m_HideAgent = gameObject.AddComponent<HideAgent>();
            }
            m_HideAgent.target = cop;
        }

        public override TaskStatus OnUpdate()
        {
            m_HideAgent.UpdateHide();
            return TaskStatus.COMPLETED;
        }
    }
}