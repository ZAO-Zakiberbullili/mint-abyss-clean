using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Land state");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isExitingState) return;

        if (player.input.x != 0)
        {
            stateMachine.ChangeState(player.moveState);
        }
        else if (isAnimationFinished)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
