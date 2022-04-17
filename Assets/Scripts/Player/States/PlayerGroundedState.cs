using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }

    public override void Enter()
    {
        base.Enter();

        player.jumpState.ResetAmountOfJumpsLeft();
    }

    public override void LogicUpdate()
    {
        if (player.input.jump && player.jumpState.CanJump())
        {
            stateMachine.ChangeState(player.jumpState);
        } 
        else if (player.CheckIfTouchingWall() && player.input.grab)
        {
            stateMachine.ChangeState(player.wallGrabState);
        }
        else if (!player.CheckIfGrounded())
        {
            player.inAirState.StartCoyoteTime();

            stateMachine.ChangeState(player.inAirState);
        }
    }
}
