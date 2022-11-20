using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/SearchWallet")]
[Help("Checks if there's a wallet at vision")]
public class SearchWallet : ConditionBase
{
    [InParam("Vision")]
    public AIVision vision;
    [OutParam("Target")]
    public GameObject target;
    public override bool Check()
    {
        if (vision.UpdateVision())
        {
            target = vision.target;
            return true;
        }
        return false;
    }
}