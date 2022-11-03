using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public class SittingState : State
{
    private CitizenFSM fsm;

    Coroutine seat = null;

    bool exit = false;
    public SittingState(StateMachine stateMachine, GameObject gameObject) : base("Sitting", stateMachine, gameObject)
    {
        fsm = (CitizenFSM)stateMachine;
    }

    public override void Enter()
    {
        exit = false;
        seat = null;
    }

    public override void Exit()
    {
        fsm.Stop(Seat());
    }

    public override void UpdateLogic()
    {
        if (seat == null)
        {
            seat = fsm.Execute(Seat());
        }
        if (exit)
        {
            fsm.ChangeState(fsm.wander);
        }
    }

    IEnumerator Seat()
    {
        yield return new WaitForSeconds(fsm.timeToWait);
        exit = true;
    }
}