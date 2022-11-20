using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

namespace BBUnity.Conditions
{
    [Condition("MyConditions/Is Shouting Near?")]
    [Help("Checks whether a Citizen is being robbed.")]
    public class IsShoutingNear : GOCondition
    {
        [InParam("Distance")]
        [Help("Distance of detect a shouting citizen")]
        public float citizenDistance;

        [OutParam("Robber")]
        [Help("Robber of the citizen.")]
        public GameObject robber;

        public override bool Check()
        {
            GameObject[] citizens = GameObject.FindGameObjectsWithTag("Citizen");

            Func<GameObject, float> distance =
                (citizen) => Vector3.Distance(gameObject.transform.position,
                                         citizen.transform.position);

            GameObject[] shoutingcitizens = citizens.Where(
                citizen => citizen.GetComponent<CitizenFSM>().Shouting()
            ).ToArray();

            (float, GameObject)[] shoutingCitizens = shoutingcitizens.Select(scitizen => (distance(scitizen), scitizen)).ToArray();

            bool shouting = false;

            if (shoutingCitizens.Length > 0)
            {
                (float, GameObject) shoutingCitizen = shoutingCitizens.Min();
                shouting = shoutingCitizen.Item1 < citizenDistance;

                if (shouting)
                {
                    robber = shoutingCitizen.Item2.GetComponent<CitizenFSM>().GetRobber();
                }
            }

            return shouting;
        }
    }
}