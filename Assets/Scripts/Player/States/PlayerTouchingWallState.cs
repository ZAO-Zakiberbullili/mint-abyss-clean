using UnityEngine;

public class PlayerTouchingWallState : PlayerState
{
    public PlayerTouchingWallState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }

    public override void Enter()
    {
        base.Enter();

        if (player.CheckIfTouchingWall() && !player.CheckIfTouchingLedge())
        {
            player.ledgeClimbState.SetDetectedPosition(player.transform.position);
        }

        Debug.Log("Touching wall state");
    }
    
    public override void LogicUpdate()
    {
        if (player.input.jump)
        {
            player.wallJumpState.DetermineWallJumpDirection();

            stateMachine.ChangeState(player.wallJumpState);
        }
        else if (player.CheckIfGrounded() && !player.input.grab)
        {
            stateMachine.ChangeState(player.idleState);
        }
        else if (!player.CheckIfTouchingWall() || (player.input.x != player.facingDirection && !player.input.grab))
        {
            stateMachine.ChangeState(player.inAirState);
        }
        else if (player.CheckIfTouchingWall() && !player.CheckIfTouchingLedge())
        {
            stateMachine.ChangeState(player.ledgeClimbState);
        }
    }
}
