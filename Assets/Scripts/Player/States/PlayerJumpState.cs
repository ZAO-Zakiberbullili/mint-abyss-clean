using UnityEngine;

public class PlayerJumpState : AbilityState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocityY(data.jumpVelocity);

        isAbilityDone = true;
    }
}
