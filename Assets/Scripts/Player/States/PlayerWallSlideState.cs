using UnityEngine;

public class PlayerWallSlideState : PlayerTouchingWallState
{
    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Wall slide state");
    }

    public override void LogicUpdate()
    {
        if (isExitingState) return;

        player.SetVelocityY(player.data.wallSlideVelocity * -1f);

        if (player.input.grab && player.input.y == 0)
        {
            stateMachine.ChangeState(player.wallGrabState);
        } 
    } 
}
