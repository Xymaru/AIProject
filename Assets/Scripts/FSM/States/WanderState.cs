using System.Collections;
using UnityEngine;
public class WanderState : State
{
    public Wander wander;
    public AIVision vision;

    private CitizenFSM fsm;

    bool canSeat = true;
    public WanderState(StateMachine stateMachine, GameObject gameObject) : base("Wander", stateMachine, gameObject)
    {
        fsm = (CitizenFSM)stateMachine;
    }

    public override void Enter()
    {
        wander = gameObject.GetComponent<Wander>();
        vision = gameObject.GetComponent<AIVision>();
    }

    public override void Exit()
    {
        fsm.moving.target = vision.target;
        canSeat = false;
        fsm.Stop(WaitToSeat());
    }

    public override void UpdateLogic()
    {
        wander.UpdateWander();
        if (!canSeat)
        {
            fsm.Execute(WaitToSeat());
        }

        if (vision.UpdateVision() && canSeat)
        {
            fsm.ChangeState(fsm.moving);
        }
    }

    IEnumerator WaitToSeat()
    {
        yield return new WaitForSeconds(fsm.timeToSeat);
        canSeat = true;
    }
}