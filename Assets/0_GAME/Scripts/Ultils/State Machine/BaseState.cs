using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : MonoBehaviour
{
    public StateMachineManager StateMachineManager { get; set; }

    public void Init(StateMachineManager manager)
    {
        StateMachineManager = manager;
    }

    public virtual void OnEnter()
    {
        // logic
    }
    public virtual void OnExit()
    {
        // logic
    }

    public virtual void OnPhysicUpdate()
    {
        // logic
    }

    public virtual void OnUpdate()
    {
        // logic
    }
}
public interface IState
{
    public State TypeState { get; }
    StateMachineManager StateMachineManager { get; set; }
    void OnEnter();
    void OnExit();
    void OnUpdate();
    void OnPhysicUpdate();
    void Init(StateMachineManager manager);
}
public enum State
{
    Idle,
    Run,
    Jump,
    Die
}
