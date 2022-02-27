using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private int xInput;

    private bool isGrounded;

    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.Input.NormInputX;

        if (isGrounded && player.currentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        else
        {
            player.CheckIfShouldFlip(xInput);
            player.SetVelocityX(data.moveVelocity * xInput);

            player.Anim.SetFloat("yVelocity", player.currentVelocity.y);
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.CheckIfGrounded();
    }
}
