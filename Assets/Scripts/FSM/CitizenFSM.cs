using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenFSM : StateMachine
{
    public WanderState wander;
    public MovingState moving;
    public SittingState sitting;
    public float timeToWait;
    public float timeToSeat;

    void Awake()
    {
        wander = new WanderState(this, gameObject);
        moving = new MovingState(this, gameObject);
        sitting = new SittingState(this, gameObject);
    }
    protected override State GetInitialState()
    {
        return wander;
    }

    public Coroutine Execute(IEnumerator routine)
    {
        return StartCoroutine(routine);
    }

    public void Stop(IEnumerator routine)
    {
        StopCoroutine(routine);
    }
}