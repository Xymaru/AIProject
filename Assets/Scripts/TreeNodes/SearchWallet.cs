using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/SearchWallet")]
[Help("Checks if there's a wallet at vision")]
public class SearchWallet : ConditionBase
{
    public AIVision vision;
    public override bool Check()
    {
        return vision.UpdateVision();
    }
}
