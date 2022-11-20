using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ShoutingState : State
{
    private CitizenFSM fsm;

    Coroutine shouting = null;

    bool exit = false;
    public ShoutingState(StateMachine stateMachine, GameObject gameObject) : base("Shouting", stateMachine, gameObject)
    {
        fsm = (CitizenFSM)stateMachine;
    }

    public override void Enter()
    {
        exit = false;
        shouting = null;
        fsm.animator.Play("Shouting");
    }

    public override void Exit()
    {
        fsm.animator.Play("UnShouting");
        fsm.Stop(Shouting());
    }

    public override void UpdateLogic()
    {
        Debug.Log("Shouting");
        if (shouting == null)
        {
            shouting = fsm.Execute(Shouting());
        }
        if (exit)
        {
            fsm.ChangeState(fsm.wander);
        }
    }

    IEnumerator Shouting()
    {
        yield return new WaitForSeconds(fsm.timeToWait);
        exit = true;
    }
}