using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public bool hasWallet = true;
    public float succesRate = 80f;

    public Action<GameObject> OnRobbed;

    public bool Rob(GameObject robber)
    {
        if(!hasWallet) return false;

        float succes = UnityEngine.Random.Range(0f, 100f);
        hasWallet = false;

        if (succes <= succesRate)
        {
            return true;
        }

        OnRobbed?.Invoke(robber);
        return false;
    }
}
