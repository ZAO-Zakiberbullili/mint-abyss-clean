using UnityEngine;

public class PlayerWallJumpState : PlayerAbilityState
{
    private int wallJumpDirection;

    public PlayerWallJumpState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }

    public override void Enter()
    {
        base.Enter();

        player.input.UseJumpInput();

        player.jumpState.ResetAmountOfJumpsLeft();

        player.SetVelocity(player.data.wallJumpVelocity, player.data.wallJumpAngle, wallJumpDirection);
        
        player.CheckIfShouldFlip(wallJumpDirection);

        player.jumpState.DecreaseAmountOfJumpsLeft();

        Debug.Log("Wall jump state");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.animator.SetFloat("yVelocity", player.GetVelocityY());

        if (Time.time > startTime + player.data.wallJumpTime)
        {
            isAbilityDone = true;
        }
    }

    public void DetermineWallJumpDirection()
    {
        if (player.CheckIfTouchingWall())
        {
            wallJumpDirection = -1 * player.facingDirection;
        } 
        else
        {
            wallJumpDirection = player.facingDirection;
        }    
    }
}
