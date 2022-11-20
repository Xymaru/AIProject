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
    }

    public override void Exit()
    {
        fsm.Stop(Shouting());
    }

    public override void UpdateLogic()
    {
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