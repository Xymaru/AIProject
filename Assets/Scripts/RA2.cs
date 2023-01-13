using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class RA2 : Agent
{
    Rigidbody rBody;
    GameObject[] Limit;

    public Transform Target;

    public bool collision = false;

    public float forceMultiplier = 10;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        // If the Agent fell, zero its momentum
        if (collision)
        {
            this.rBody.angularVelocity = Vector3.zero;
            this.rBody.velocity = Vector3.zero;
            this.transform.localPosition = new Vector3(-2.36f, 1.37f, 8.31f);

            collision = false;
        }

        // Move the target to a new spot
        Target.localPosition = new Vector3(Random.Range(30, -30),
                                           1.1f,
                                           Random.Range(30, -30));
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Target and Agent positions
        sensor.AddObservation(Target.localPosition);
        sensor.AddObservation(this.transform.localPosition);

        // Agent velocity
        sensor.AddObservation(rBody.velocity.x);
        sensor.AddObservation(rBody.velocity.z);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Actions, size = 2
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actionBuffers.ContinuousActions[0];
        controlSignal.z = actionBuffers.ContinuousActions[1];
        rBody.AddForce(controlSignal * forceMultiplier);

        // Rewards
        float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);

        // Reached target
        if (distanceToTarget < 1f)
        {
            Debug.Log("Reward!");
            SetReward(1.0f);
            EndEpisode();
        }

        else if (GetComponent<Collider>().transform.tag != "Untagged")
        {
            SetReward(-1.0f);
            EndEpisode();
        }

        else if (transform.localPosition.y < 0 || transform.localPosition.y > 2)
        {
            SetReward(-1.0f);
            EndEpisode();
            collision = true;
        }

        else if (transform.localPosition.x < -20 || transform.localPosition.x > 40)
        {
            SetReward(-1.0f);
            EndEpisode();
            collision = true;
        }

        else if (transform.localPosition.z < -25 || transform.localPosition.y > 30)
        {
            SetReward(-1.0f);
            EndEpisode();
            collision = true;
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");
    }
}
