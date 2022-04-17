using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private bool coyoteTime;
    private bool isJumping;

    private bool wallJumpCoyoteTime;
    private float startWallJumpCoyoteTime;

    private bool isTouchingWall;
    private bool isTouchingWallBack;
    private bool oldIsTouchingWall;
    private bool oldIsTouchingWallBack;

    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }

    public override void Enter()
    {
        oldIsTouchingWall = isTouchingWall;
        oldIsTouchingWallBack = isTouchingWallBack;

        isTouchingWall = player.CheckIfTouchingWall();
        isTouchingWallBack = player.CheckIfTouchingWallBack();

        if (isTouchingWall && !player.CheckIfTouchingLedge())
        {
            player.ledgeClimbState.SetDetectedPosition(player.transform.position);
        }

        if (!wallJumpCoyoteTime && !isTouchingWall && !isTouchingWallBack && (oldIsTouchingWall || oldIsTouchingWallBack))
        {
            StartWallJumpCoyoteTime();
        }

        Debug.Log("In air state");
    }

    public override void LogicUpdate()
    {
        CheckCoyoteTime();

        CheckWallJumpCoyoteTime();

        CheckJumpMultiplier();

        if (player.CheckIfGrounded() && player.GetVelocityY() < 0.01f)
        {
            stateMachine.ChangeState(player.landState);
        } 
        else if (player.CheckIfTouchingWall() && !player.CheckIfTouchingLedge())
        {
            stateMachine.ChangeState(player.ledgeClimbState);
        }
        else if (player.input.jump && (player.CheckIfTouchingWall() || player.CheckIfTouchingWallBack() || wallJumpCoyoteTime))
        {
            StopWallJumpCoyoteTime();

            player.wallJumpState.DetermineWallJumpDirection();

            stateMachine.ChangeState(player.wallJumpState);
        }
        else if (player.input.jump && player.jumpState.CanJump())
        {
            stateMachine.ChangeState(player.jumpState);
        }
        else if (player.CheckIfTouchingWall() && player.input.grab)
        {
            stateMachine.ChangeState(player.wallGrabState);
        }
        else if (player.CheckIfTouchingWall() && player.input.x == player.facingDirection && player.GetVelocityY() < 0f)
        {
            stateMachine.ChangeState(player.wallSlideState);
        }
        else
        {
            player.CheckIfShouldFlip(player.input.x);

            player.SetVelocityX(player.data.moveVelocity * player.input.x);

            player.animator.SetFloat("yVelocity", player.GetVelocityY());
        }
    }

    public override void Exit()
    {
        base.Exit();

        oldIsTouchingWall = false;
        oldIsTouchingWallBack = false;
        isTouchingWall = false;
        isTouchingWallBack = false;
    }

    private void CheckJumpMultiplier()
    {
        if (isJumping)
        {
            if (player.input.jumpStop)
            {
                player.SetVelocityY(player.GetVelocityY() * player.data.jumpHeightMultiplier);

                isJumping = false;
            }
            else if (player.GetVelocityY() <= 0)
            {
                isJumping = false;
            }
        }
    }

    private void CheckCoyoteTime()
    {
        if (coyoteTime && Time.time > startTime + player.data.coyoteTime)
        {
            coyoteTime = false;

            player.jumpState.DecreaseAmountOfJumpsLeft();
        }
    }

    public void StartCoyoteTime()
    {
        coyoteTime = true;

        startWallJumpCoyoteTime = Time.time;
    }

    private void CheckWallJumpCoyoteTime()
    {
        if (wallJumpCoyoteTime && Time.time > startWallJumpCoyoteTime + player.data.coyoteTime)
        {
            wallJumpCoyoteTime = false;

            // player.jumpState.DecreaseAmountOfJumpsLeft();
        }
    }

    public void StartWallJumpCoyoteTime()
    {
        wallJumpCoyoteTime = true;
    }

    public void StopWallJumpCoyoteTime()
    {
        wallJumpCoyoteTime = false;
    }

    public void SetIsJumping()
    {
        isJumping = true;
    }
}
