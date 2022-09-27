using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.AI;
public class HideAgent : MonoBehaviour
{
    public GameObject[] hidingSpots;
    public GameObject target;
    public NavMeshAgent meshAgent;
    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        hidingSpots = GameObject.FindGameObjectsWithTag("hide");
    }

    // Update is called once per frame
    void Update()
    {
        Hide();
    }

    void Hide()
    {
        Func<GameObject, float> distance =
            (hs) => Vector3.Distance(target.transform.position,
                                     hs.transform.position);
        GameObject hidingSpot = hidingSpots.Select(
            ho => (distance(ho), ho)
            ).Min().Item2;
        Vector3 dir = hidingSpot.transform.position - target.transform.position;
        Debug.Log(dir);
        Ray backRay = new Ray(hidingSpot.transform.position, -dir.normalized);
        RaycastHit info;
        Debug.DrawLine(backRay.origin, backRay.direction, Color.red);
        hidingSpot.GetComponent<Collider>().Raycast(backRay, out info, 30f);
        Debug.Log(backRay.origin + " " + backRay.direction);
        Debug.Log(info.point + " " + dir.normalized); 
        meshAgent.destination = (info.point + dir.normalized);
    }
}
