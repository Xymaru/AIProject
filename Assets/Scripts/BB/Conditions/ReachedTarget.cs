using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

namespace BBUnity.Conditions
{
    [Condition("MyConditions/Reached target?")]
    [Help("Checks whether agent reached a target.")]
    public class ReachedTarget : GOCondition
    {
        [InParam("Distance")]
        [Help("Distance of reach.")]
        public float reachDistance;

        [InParam("Target")]
        [Help("Target to check.")]
        public GameObject target;

        public override bool Check()
        {
            return Vector3.Distance(target.transform.position, gameObject.transform.position) <= reachDistance;
        }
    }
}