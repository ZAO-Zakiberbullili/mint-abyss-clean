using UnityEngine;

public class PlayerLandState : GroundedState
{
    public PlayerLandState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (xInput != 0)
        {
            stateMachine.ChangeState(player.MoveState);
        }   
        else if (isAnimationFinished)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }
}
