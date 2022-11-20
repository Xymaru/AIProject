using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    State currentState;

    public TMPro.TextMeshPro stateText;

    void Start()
    {

        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();
    }

    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
    }


    public void ChangeState(State newState)
    {
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    protected virtual State GetInitialState()
    {
        return null;
    }

    public string GetCurrentStateName()
    {
        return currentState.name;
    }
}
