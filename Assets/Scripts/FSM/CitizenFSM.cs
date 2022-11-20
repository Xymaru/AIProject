using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenFSM : StateMachine
{
    public WanderState wander;
    public MovingState moving;
    public SittingState sitting;
    public ShoutingState shouting;
    public float timeToWait;
    public float timeToShout;
    public float timeToSeat;
    public Animator animator;

    private Wallet wallet;
    private GameObject m_Robber;

    void Awake()
    {
        wander = new WanderState(this, gameObject);
        moving = new MovingState(this, gameObject);
        sitting = new SittingState(this, gameObject);
        shouting = new ShoutingState(this, gameObject);

        wallet = gameObject.GetComponent<Wallet>();

        if (!wallet)
        {
            wallet = gameObject.AddComponent<Wallet>();
        }

        wallet.OnRobbed = OnRobbed;
    }
    protected override State GetInitialState()
    {
        return wander;
    }
    public void StopAll()
    {
        StopAllCoroutines();
    }
    public Coroutine Execute(IEnumerator routine)
    {
        return StartCoroutine(routine);
    }

    public void Stop(IEnumerator routine)
    {
        StopCoroutine(routine);
    }

    public void OnRobbed(GameObject robber)
    {
        m_Robber = robber;
        ChangeState(shouting);
    }

    public bool Shouting()
    {
        return GetCurrentStateName() == "Shouting";
    }

    public GameObject GetRobber()
    {
        return m_Robber;
    }
}