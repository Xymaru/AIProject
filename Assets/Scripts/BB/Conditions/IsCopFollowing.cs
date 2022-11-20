using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

namespace BBUnity.Conditions
{
    [Condition("MyConditions/Is Cop Following?")]
    [Help("Checks whether Cop is following.")]
    public class IsCopFollowing : GOCondition
    {
        [OutParam("Cop")]
        [Help("Following cop")]
        public GameObject cop;

        public override bool Check()
        {
            GameObject[] cops = GameObject.FindGameObjectsWithTag("Cop");

            GameObject[] seekers = cops.Where(cop => cop.gameObject.GetComponent<SeekController>()).ToArray();

            GameObject[] followers = seekers.Where(cop => cop.gameObject.GetComponent<SeekController>().target == gameObject).ToArray();

            bool following = followers.Length > 0;

            if (following){
                cop = followers[0];
                Debug.Log(cop); 
            }
            return following;
        }
    }
}