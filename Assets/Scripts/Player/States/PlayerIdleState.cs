using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Idle state");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.SetVelocityX(0f);

        if (player.input.x != 0f && !isExitingState)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }
}
