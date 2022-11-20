using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    public GameObject poop;
    Coroutine poopingCoroutine;
    public float timeToPoop = 10.0f;
    void Update()
    {
        if (poopingCoroutine == null)
        {
            poopingCoroutine = StartCoroutine(Pooping());
        }
    }
    IEnumerator Pooping()
    {
        yield return new WaitForSeconds(timeToPoop);
        int chance = Random.Range(0, 100);
        if (chance % 2 == 0)
        {
            Instantiate(poop, gameObject.transform.position, Quaternion.identity);
        }
        Debug.Log("Poop");
        poopingCoroutine = null;
    }
}
