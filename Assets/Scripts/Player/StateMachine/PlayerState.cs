using UnityEngine;

public class PlayerState : State
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData data;

    private string animation;

    protected bool isAnimationFinished;
    protected bool isExitingState;

    protected float startTime;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.data = data;
        this.animation = animation;
    }

    public override void Enter()
    {
        player.animator.SetBool(animation, true);

        isAnimationFinished = false;
        isExitingState = false;

        startTime = Time.time;
    }

    public override void Exit()
    {
        isExitingState = true;

        player.animator.SetBool(animation, false);
    }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}
