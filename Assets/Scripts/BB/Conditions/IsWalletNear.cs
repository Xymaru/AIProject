using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

using Pada1.BBCore;
using Pada1.BBCore.Framework;

namespace BBUnity.Conditions
{
    [Condition("MyConditions/Is Wallet Near?")]
    [Help("Checks whether Wallet is near.")]
    public class IsWalletNear : GOCondition
    {
        [InParam("Distance")]
        [Help("Distance of wallet to find")]
        public float walletDistance;

        [OutParam("Target")]
        [Help("Target to steal wallet from")]
        public GameObject target;

        public override bool Check()
        {
            GameObject[] citizens = GameObject.FindGameObjectsWithTag("Citizen");

            Func<GameObject, float> distance =
                (cop) => Vector3.Distance(gameObject.transform.position,
                                         cop.transform.position);

            GameObject[] wallets = citizens.Where(cit => cit.GetComponent<Wallet>().hasWallet).ToArray();

            if(wallets.Length > 0)
            {
                (float, GameObject) wallet = wallets.Select(w => (distance(w), w)).Min();

                target = wallet.Item2;

                return wallet.Item1 < walletDistance;
            }

            return false;
        }
    }
}