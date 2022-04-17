using UnityEngine;

public class PlayerWallGrabState : PlayerTouchingWallState
{
    private Vector2 holdPosition;

    public PlayerWallGrabState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }

    public override void Enter()
    {
        base.Enter();

        holdPosition = player.transform.position;

        HoldPosition();

        Debug.Log("Wall grab state");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isExitingState) return;

        HoldPosition();

        if (player.input.y > 0)
        {
            stateMachine.ChangeState(player.wallClimbState);
        }
        else if (player.input.y < 0 || !player.input.grab)
        {
            stateMachine.ChangeState(player.wallSlideState);
        }
    }

    private void HoldPosition()
    {
        player.transform.position = holdPosition;

        player.SetVelocityX(0f);
        player.SetVelocityY(0f);
    }
}
