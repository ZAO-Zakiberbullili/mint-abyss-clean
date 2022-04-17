using UnityEngine;

public class PlayerWallClimbState : PlayerTouchingWallState
{
    public PlayerWallClimbState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Wall climb state");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isExitingState) return;

        player.SetVelocityY(player.data.wallClimbVelocity);

        if (player.input.y != 1)
        {
            stateMachine.ChangeState(player.wallGrabState);
        }
    }
}
