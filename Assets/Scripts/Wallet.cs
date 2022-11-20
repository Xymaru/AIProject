using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public bool hasWallet { get; private set; } = true;
    public float succesRate = 80f;

    public Action<GameObject> OnRobbed;

    public bool Rob(GameObject robber)
    {
        if(!hasWallet) return false;

        float succes = UnityEngine.Random.Range(0f, 100f);

        if (succes <= succesRate)
        {
            hasWallet = false;
            Debug.Log("Wallet steal was succesfull");
            return true;
        }

        OnRobbed?.Invoke(robber);

        return false;
    }
}
