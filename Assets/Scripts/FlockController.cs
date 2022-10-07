using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockController : MonoBehaviour
{
    [Header("Flocking options")]
    [SerializeField] private GameObject prefab;
    [SerializeField] private int numPrefabs;
    [SerializeField] public GameObject[] allPrefabs;
    [SerializeField] private Vector3 flockLimits;
    //[SerializeField] private bool bounded;
    //[SerializeField] private bool randomize;
    //[SerializeField] private GameObject lider;

    [Header("Agent Options")]
    [Range(0f, 10f)] public float minSpeed;
    [Range(0f, 10f)] public float maxSpeed;
    [Range(0f, 10f)] public float neighbourDistance;
    [Range(0f, 10f)] public float rotationSpeed;

    void Start()
    {
        allPrefabs = new GameObject[numPrefabs];
        for (int i = 0; i < allPrefabs.Length; ++i)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-flockLimits.x, flockLimits.x),
                                                       Random.Range(-flockLimits.y, flockLimits.y),
                                                       Random.Range(-flockLimits.z, flockLimits.z));
            allPrefabs[i] = (GameObject)Instantiate(prefab, pos, Quaternion.identity);
            allPrefabs[i].GetComponent<Flock>().controller = this;
        }
    }




}
