using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MonoBehaviour, IState
{
    public StateMachineManager StateMachineManager { get; set ; }

    public State TypeState => State.Idle;

    public void Init(StateMachineManager manager)
    {
        StateMachineManager = manager;
    }

    public void OnEnter()
    {
        Debug.Log("Enter Idle");
    }

    public void OnExit()
    {
        Debug.Log("Exit Idle");
    }

    public void OnPhysicUpdate()
    {
    }

    public void OnUpdate()
    {
    }
}
