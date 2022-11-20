using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

namespace BBUnity.Conditions
{
    [Condition("MyConditions/Is Poop Near?")]
    [Help("Checks whether poop is near.")]
    public class IsPoopNear : GOCondition
    {
        [InParam("Distance")]
        [Help("Distance of poop")]
        public float poopDistance;

        [OutParam("Poop")]
        [Help("Nearest poop")]
        public GameObject poop;

        public override bool Check()
        {
            GameObject[] poops = GameObject.FindGameObjectsWithTag("poop");

            Func<GameObject, float> distance =
                (poop) => Vector3.Distance(gameObject.transform.position,
                                         poop.transform.position);

            (float, GameObject)[] poopslist = poops.Select(
                poop => (distance(poop), poop)
                ).ToArray();

            bool poopNear = false;

            if (poops.Length > 0)
            {
                (float, GameObject) pp = poopslist.Min();

                poopNear = pp.Item1 < poopDistance;
                poop = pp.Item2;
            }

            return poopNear;
        }
    }
}