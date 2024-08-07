using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineManager : SerializedMonoBehaviour
{
    public IState currentState;

    [SerializeField] JumpState jumpState;
    [SerializeField] IdleState idleState;
    [SerializeField] RunState runState;
    public Dictionary<State, IState> states = new Dictionary<State, IState>();

    private void Awake()
    {
        foreach(var x in states.Keys)
        {
            states[x].Init(this);
        }
        currentState = states[State.Idle];
    }
    [Button("Change State")]
    public void ChangeState(State stateName)
    {
        currentState.OnExit();
        currentState = states[stateName];
        currentState.OnEnter();
    }

    private void Update()
    {
        currentState.OnUpdate();
    }
    private void FixedUpdate()
    {
        currentState.OnPhysicUpdate();
    }
}
