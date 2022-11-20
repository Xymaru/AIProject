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
        fsm.animator.SetBool("Shouting", true);
    }

    public override void Exit()
    {
        fsm.animator.SetBool("Shouting", false);
    }

    public override void UpdateLogic()
    {
        if (shouting == null)
        {
            shouting = fsm.Execute(Shouting());
        }
        if (exit)
        {
            Debug.Log("Stopped shouting");
            fsm.ChangeState(fsm.wander);
        }
    }

    IEnumerator Shouting()
    {
        Debug.Log("Shouting");
        yield return new WaitForSeconds(fsm.timeToShout);
        exit = true;
        shouting = null;
    }
}