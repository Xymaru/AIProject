using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public bool hasWallet { get; private set; } = true;
    public float succesRate = 80f;

    public static Action<GameObject> OnShout;
    public bool Rob(GameObject robber)
    {
        float succes = UnityEngine.Random.Range(0f, 100f);

        if (succes <= succesRate)
        {
            hasWallet = false;
            return true;
        }

        OnShout?.Invoke(robber);

        return false;
    }

}
