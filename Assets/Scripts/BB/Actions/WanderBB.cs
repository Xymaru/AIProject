using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using UnityEngine.AI;

namespace BBUnity.Actions
{
    [Action("MyActions/Wander")]
    [Help("Agent wander around")]
    public class WanderBB : GOAction
    {
        private Wander wander;

        [InParam("Radius")]
        [Help("Radius to wander")]
        public float radius;

        public override void OnStart()
        {
            wander = gameObject.GetComponent<Wander>();
            if (wander == null)
            {
                wander = gameObject.AddComponent<Wander>();
                wander.SetWanderRadius(radius);
            }
        }

        public override TaskStatus OnUpdate()
        {
            wander.UpdateWander();
            return TaskStatus.COMPLETED;
        }
    }
}