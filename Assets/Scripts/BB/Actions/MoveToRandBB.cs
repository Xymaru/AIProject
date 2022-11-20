using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using UnityEngine.AI;

namespace BBUnity.Actions
{
    [Action("MyActions/MoveToRand")]
    [Help("Agent move to random position using NavMesh")]
    public class MoveToRand : GOAction
    {
        private NavMeshAgent navAgent;

        [InParam("Offset")]
        [Help("Offset area to find position")]
        public Vector3 offset;

        [InParam("Radius")]
        [Help("Radius to find position in area")]
        public float radius;

        public override void OnStart()
        {
            navAgent = gameObject.GetComponent<NavMeshAgent>();
            if (navAgent == null)
            {
                Debug.LogWarning("The " + gameObject.name + " game object does not have a Nav Mesh Agent component to navigate. One with default values has been added", gameObject);
                navAgent = gameObject.AddComponent<NavMeshAgent>();
            }

            navAgent.SetDestination(NavUtils.RandomNavSphere(offset, radius, -1));
        }

        public override TaskStatus OnUpdate()
        {
            if (!navAgent.pathPending && !navAgent.hasPath)
                return TaskStatus.COMPLETED;
            return TaskStatus.RUNNING;
        }
    }
}