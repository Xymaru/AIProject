using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus


namespace BBUnity.Actions
{
    [Action("MyActions/Flee")]
    [Help("Agent flee from target")]
    public class FleeBB : GOAction
    {
        [InParam("game object")]
        [Help("Game object to flee from")]
        public GameObject targetGameobject;

        public override TaskStatus OnUpdate()
        {
            FleeController hide = targetGameobject.GetComponent<FleeController>();
            hide.UpdateFlee();
            return TaskStatus.COMPLETED;
        }
    }
}