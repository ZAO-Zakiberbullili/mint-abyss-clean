using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData data;

    protected bool isAnimationFinished;

    private string animation;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData data, string animation)
    {
        this.player = player;
        this.stateMachine = stateMachine;   
        this.data = data;
        this.animation = animation;
    }

    public virtual void Enter()
    {
        DoChecks();
        player.Anim.SetBool(animation, true);
        isAnimationFinished = false;
    }

    public virtual void Exit() 
    {
        player.Anim.SetBool(animation, false);
    }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks() { }

    public virtual void AnimationTrigger () { }

    public virtual void AnimationFinishTrigger() 
    {
        isAnimationFinished = true;
    }
}
