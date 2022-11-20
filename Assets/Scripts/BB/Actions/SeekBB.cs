using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus

namespace BBUnity.Actions
{
    [Action("MyActions/Seek")]
    [Help("Seek a given target")]
    public class SeekBB : GOAction
    {
        SeekController m_Seeker;

        [InParam("Target")]
        [Help("Target to seek")]
        public GameObject targetGameobject;

        private float m_SeekTime = 15.0f;
        private float m_SeekTimer = 0.0f;

        public override void OnStart()
        {
            m_Seeker = gameObject.GetComponent<SeekController>();
            if (!m_Seeker)
            {
                m_Seeker = gameObject.AddComponent<SeekController>();
            }
            m_Seeker.target = targetGameobject;

            m_SeekTimer = 0.0f;
        }

        public override TaskStatus OnUpdate()
        {
            m_SeekTimer += Time.deltaTime;

            bool reached = m_Seeker.UpdateSeek();
            if (reached)
                return TaskStatus.COMPLETED;
            else if(m_SeekTimer >= m_SeekTime)
            {
                m_Seeker.target = m_Seeker.gameObject;
                return TaskStatus.COMPLETED;
            }
            return TaskStatus.RUNNING;
        }
    }
}