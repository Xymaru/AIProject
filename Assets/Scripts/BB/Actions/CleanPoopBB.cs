using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus

namespace BBUnity.Actions
{
    [Action("MyActions/Clean poop")]
    [Help("Clean poop")]
    public class CleanPoopBB : GOAction
    {
        [InParam("Poop")]
        [Help("Poop to clean")]
        public GameObject poop;

        public override TaskStatus OnUpdate()
        {
            poop.GetComponent<PoopController>().Clean();
            return TaskStatus.COMPLETED;
        }
    }
}
