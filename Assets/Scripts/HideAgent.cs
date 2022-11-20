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

    public void UpdateHide()
    {
        Hide();
    }

    void Hide()
    {
        if (meshAgent == null) return;

        Func<GameObject, float> distance =
            (hs) => Vector3.Distance(target.transform.position,
                                     hs.transform.position);

        (float, GameObject) result = hidingSpots.Select(
            ho => (distance(ho), ho)
            ).Min();

        GameObject hidingSpot = result.Item2;
        Vector3 dir = hidingSpot.transform.position - target.transform.position;

        Ray backRay = new Ray(hidingSpot.transform.position, -dir.normalized);
        RaycastHit info;
        Debug.DrawLine(backRay.origin, backRay.direction, Color.red);
        hidingSpot.GetComponent<Collider>().Raycast(backRay, out info, 2000f);

        meshAgent.destination = (info.point + dir.normalized);
    }
}
