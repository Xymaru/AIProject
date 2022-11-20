using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

namespace BBUnity.Conditions
{
    [Condition("MyConditions/Has target?")]
    [Help("Checks whether a target is not null")]
    public class HasTargetBB : GOCondition
    {
        [InParam("Target")]
        [Help("Target to check")]
        public GameObject target;

        public override bool Check()
        {
            return target != null;
        }
    }
}