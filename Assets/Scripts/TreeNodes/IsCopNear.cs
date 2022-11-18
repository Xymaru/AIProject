using UnityEngine;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

[Condition("MyConditions/Is Cop Near?")]
[Help("Checks whether Cop is near the Treasure.")]
public class IsCopNear : ConditionBase
{
    [InParam("target")]
    public GameObject target;
    public override bool Check()
    {
        GameObject cop = GameObject.Find("Cop");
        return Vector3.Distance(cop.transform.position, target.transform.position) < 10f;
    }
}
