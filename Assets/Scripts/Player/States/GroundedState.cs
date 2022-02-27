using UnityEngine;

public class GroundedState : PlayerState
{
    protected int xInput;

    private bool jumpInput;

    public GroundedState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.Input.NormInputX;

        jumpInput = player.Input.Jump;

        if (jumpInput)
        {
            player.Input.UseJumpInput();
            stateMachine.ChangeState(player.JumpState);
        }
    }
}
