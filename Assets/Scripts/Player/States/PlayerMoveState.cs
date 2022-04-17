using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Move state");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.CheckIfShouldFlip(player.input.x);

        player.SetVelocityX(player.data.moveVelocity * player.input.x);

        if (player.input.x == 0f && !isExitingState)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
