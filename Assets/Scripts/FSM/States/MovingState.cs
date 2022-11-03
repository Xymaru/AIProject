using UnityEngine;
using UnityEngine.AI;

public class MovingState : State
{
    NavMeshAgent agent;
    public GameObject target;

    private CitizenFSM fsm;
    public MovingState(StateMachine stateMachine, GameObject gameObject) : base("Moving", stateMachine, gameObject)
    {
        fsm = (CitizenFSM)stateMachine;
    }

    public override void Enter()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
    }

    public override void Exit()
    {

    }

    public override void UpdateLogic()
    {
        if (!agent.pathPending && !agent.hasPath)
        {
            fsm.ChangeState(fsm.sitting);
        }
    }
}