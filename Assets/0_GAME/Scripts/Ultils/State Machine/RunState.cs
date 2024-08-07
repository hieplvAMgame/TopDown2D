using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : MonoBehaviour, IState
{
    public StateMachineManager StateMachineManager { get; set; }

    public State TypeState => State.Run;

    public void Init(StateMachineManager manager)
    {
        StateMachineManager = manager;
    }

    public void OnEnter()
    {
        Debug.Log("Enter run");
    }

    public void OnExit()
    {
        Debug.Log("Exit run");
    }

    public void OnPhysicUpdate()
    {
    }

    public void OnUpdate()
    {
    }
}
