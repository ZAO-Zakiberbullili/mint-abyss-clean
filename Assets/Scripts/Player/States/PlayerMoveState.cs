using UnityEngine;

public class PlayerMoveState : GroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.CheckIfShouldFlip(xInput);

        player.SetVelocityX(data.moveVelocity * xInput);

        if (xInput == 0f)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }
}
