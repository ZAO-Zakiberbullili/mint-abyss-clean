using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public new PlayerState currentState;

    public void Init(PlayerState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
