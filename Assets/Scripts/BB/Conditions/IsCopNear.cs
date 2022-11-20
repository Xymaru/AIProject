using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

using Pada1.BBCore;
using Pada1.BBCore.Framework;


[Condition("MyConditions/Is Cop Near?")]
[Help("Checks whether Cop is near the target.")]
public class IsCopNear : ConditionBase
{
    [InParam("Target")]
    [Help("Target to steal from")]
    public GameObject targetGameobject;

    [InParam("Distance")]
    [Help("Distance of cop to target")]
    public float copDistance;

    public override bool Check()
    {
        GameObject[] cops = GameObject.FindGameObjectsWithTag("Cop");

        Func<GameObject, float> distance =
            (cop) => Vector3.Distance(targetGameobject.transform.position,
                                     cop.transform.position);

        float copdist = cops.Select(
            cop => (distance(cop))
            ).Min();

        return copdist < copDistance;
    }
}