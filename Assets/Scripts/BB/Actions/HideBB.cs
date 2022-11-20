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

        [InParam("Seeker")]
        [Help("Seeker to hide from")]
        public GameObject seeker;

        public override void OnStart()
        {
            m_HideAgent = gameObject.GetComponent<HideAgent>();
            if (!m_HideAgent)
            {
                m_HideAgent = gameObject.AddComponent<HideAgent>();
            }
            m_HideAgent.target = seeker;
        }

        public override TaskStatus OnUpdate()
        {
            m_HideAgent.UpdateHide();
            return TaskStatus.COMPLETED;
        }
    }
}