using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus

namespace BBUnity.Actions
{
    [Action("MyActions/Steal wallet")]
    [Help("Steal wallet from target")]
    public class StealWalletBB : GOAction
    {
        [InParam("Target")]
        [Help("Target to steal")]
        public GameObject targetGameobject;

        public override TaskStatus OnUpdate()
        {
            Wallet wallet = targetGameobject.GetComponent<Wallet>();

            bool robbed = wallet.Rob(gameObject);

            if (robbed)
            {
                return TaskStatus.COMPLETED;
            }

            return TaskStatus.FAILED;
        }
    }
}