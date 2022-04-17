using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool isAbilityDone;

    public PlayerAbilityState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }

    public override void Enter()
    {
        base.Enter();

        isAbilityDone = false;

        Debug.Log("Ability state");
    }

    public override void LogicUpdate()
    {
        if (isAbilityDone)
        {
            if (player.CheckIfGrounded() && player.GetVelocityY() < 0.01f)
            {
                stateMachine.ChangeState(player.idleState);
            }
            else
            {
                stateMachine.ChangeState(player.inAirState);
            }
        }
    }
}
