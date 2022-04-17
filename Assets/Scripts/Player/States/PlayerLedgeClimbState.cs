using UnityEngine;

public class PlayerLedgeClimbState : PlayerState
{
    private Vector2 detectedPosition;
    private Vector2 cornerPosition;

    private Vector2 startPosition;
    private Vector2 stopPosition;

    private Vector2 startOffset = new Vector2(0.4f, 0.9f);
    private Vector2 stopOffset = new Vector2(0.4f, 0.75f);

    private bool isHanging;
    private bool isClimbing;

    public PlayerLedgeClimbState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocityZero();

        player.transform.position = detectedPosition;

        cornerPosition = player.DetermineCornerPosition();

        startPosition.Set(cornerPosition.x - (player.facingDirection * startOffset.x), cornerPosition.y - startOffset.y);
        stopPosition.Set(cornerPosition.x + (player.facingDirection * stopOffset.x), cornerPosition.y + stopOffset.y);

        player.transform.position = startPosition;
    }

    public override void LogicUpdate()
    {
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(player.idleState);
        }

        player.SetVelocityZero();

        player.transform.position = startPosition;

        if (player.input.x == player.facingDirection && isHanging && !isClimbing)
        {
            isClimbing = true;

            player.animator.SetBool("climbLedge", true);
        }
        else if (player.input.y == -1 && isHanging && !isClimbing)
        {
            stateMachine.ChangeState(player.inAirState);
        }
        else if (player.input.jump && !isClimbing)
        {
            player.wallJumpState.DetermineWallJumpDirection();

            stateMachine.ChangeState(player.wallJumpState);
        }
    }

    public override void Exit()
    {
        base.Exit();

        isHanging = false;

        if (isClimbing)
        {
            player.transform.position = stopPosition;

            isClimbing = false;
        }
    }

    public override void AnimationTrigger()
    {
        isHanging = true;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        player.animator.SetBool("climbLedge", false);
    }

    public void SetDetectedPosition(Vector2 position)
    {
        detectedPosition = position;
    }
}
