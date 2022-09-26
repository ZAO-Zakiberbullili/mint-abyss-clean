using UnityEngine;

public class Player : MonoBehaviour
{
    #region StateVariables
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }

    [SerializeField] 
    private PlayerData data;
    #endregion

    #region Components
    public Animator Anim { get; private set; }
    public InputHandler Input { get; private set; }
    public Rigidbody2D RB { get; private set; }
    #endregion

    [SerializeField]
    private Transform groundCheck;

    [HideInInspector]
    public Vector2 currentVelocity;

    public int FacingDirection { get; private set; }

    #region  Unity Callback Functions
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, data, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, data, "move");
        JumpState = new PlayerJumpState(this, StateMachine, data, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, data, "inAir");
        LandState = new PlayerLandState(this, StateMachine, data, "land");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        Input = GetComponent<InputHandler>();
        RB = GetComponent<Rigidbody2D>();

        FacingDirection = 1;

        StateMachine.Init(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();

        currentVelocity = RB.velocity;
    }
    #endregion

    #region Set Functions
    public void SetVelocityX(float velocity)
    {
        RB.velocity = new Vector2(velocity, RB.velocity.y);
    }

    public void SetVelocityY(float velocity)
    {
        RB.velocity = new Vector2(RB.velocity.x, velocity);
    }
    #endregion

    #region Check Functions
    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, data.groundCheckRadius, data.whatIsGround);
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }
    #endregion

    private void AnimationTriggerFunction()
    {
        StateMachine.CurrentState.AnimationTrigger();
    }

    private void AnimationFinishTrigger()
    {
        StateMachine.CurrentState.AnimationFinishTrigger();
    }

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
