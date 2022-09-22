using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobberController : MonoBehaviour
{
    public Transform target;
    public float maxVelocity = 30.0f;
    public float turnSpeed = 50.0f;
    public Vector3 direction;
    public Vector3 movement;
    public float angle;
    public Quaternion rotation;
    float freq = 0f;
    void Start()
    {
        direction = transform.position;
        movement = Vector3.zero;
        angle = transform.rotation.y;
        rotation = transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        freq += Time.deltaTime;
        if (freq > 0.05)
        {
            freq -= 0.05f;
            Seek();
        }
    }
    void Seek()
    {
        direction = target.transform.position - transform.position;
        direction.y = 0.0f;

        movement = direction.normalized * maxVelocity;
        angle = Mathf.Rad2Deg* Mathf.Atan2(movement.x, movement.z);
        rotation = Quaternion.AngleAxis(angle, Vector3.up);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * maxVelocity * Time.deltaTime;
    }
}
