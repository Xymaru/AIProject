using System.Collections;
using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Condition("MyConditions/StealWallet")]
[Help("Checks if there's a wallet at vision")]
public class StealWallet : ConditionBase
{
    [InParam("Wallet")]
    GameObject wallet;
    [InParam("Robber")]
    GameObject robber;
    public override bool Check()
    {
        Debug.Log("Trying to steal wallet");
        return wallet.GetComponent<Wallet>().Rob(robber);
    }
}

