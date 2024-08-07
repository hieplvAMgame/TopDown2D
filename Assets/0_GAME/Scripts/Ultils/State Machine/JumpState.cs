using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : MonoBehaviour, IState
{
    public StateMachineManager StateMachineManager { get ; set; }
    public State TypeState { get => State.Jump; }

    public void Init(StateMachineManager manager)
    {
        StateMachineManager = manager;
        // if(!manager.dict.contaniskey(TypeState))
        // manager.add(TypeState,this);
    }

    public void OnEnter()
    {
        Debug.Log("Enter jump");
    }

    public void OnExit()
    {
        Debug.Log("Exit jump");
    }

    public void OnPhysicUpdate()
    {
    }

    public void OnUpdate()
    {
    }
}
