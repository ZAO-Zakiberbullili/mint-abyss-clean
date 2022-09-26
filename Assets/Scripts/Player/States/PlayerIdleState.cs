using UnityEngine;

public class PlayerIdleState : GroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.SetVelocityX(0f);

        if (xInput != 0f)
        {
            stateMachine.ChangeState(player.MoveState);
        }
    }
}
