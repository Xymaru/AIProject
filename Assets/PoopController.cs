using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopController : MonoBehaviour
{
    public bool cleaned = false;
    public void Clean()
    {
        cleaned = true;
        Destroy(gameObject);

    }
}
