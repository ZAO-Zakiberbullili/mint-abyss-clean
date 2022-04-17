using UnityEngine;

public class PlayerFallState : PlayerState
{
    public PlayerFallState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation) : base(player, stateMachine, data, animation) { }
}
