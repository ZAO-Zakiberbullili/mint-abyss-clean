using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private int amountOfJumpsLeft;

    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) 
    {
        amountOfJumpsLeft = player.data.amountOfJumps;
    }

    public override void Enter()
    {
        base.Enter();

        player.input.UseJumpInput();

        player.SetVelocityY(player.data.jumpVelocity);

        isAbilityDone = true;

        amountOfJumpsLeft--;

        player.inAirState.SetIsJumping();

        Debug.Log("Jump state");
    }

    public bool CanJump()
    {
        if (amountOfJumpsLeft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetAmountOfJumpsLeft()
    {
        amountOfJumpsLeft = player.data.amountOfJumps;
    }

    public void DecreaseAmountOfJumpsLeft()
    {
        amountOfJumpsLeft--;
    }
}
