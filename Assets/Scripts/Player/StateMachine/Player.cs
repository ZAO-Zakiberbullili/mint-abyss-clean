using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine stateMachine;

    public PlayerIdleState idleState;
    public PlayerMoveState moveState;
    public PlayerInAirState inAirState;
    public PlayerJumpState jumpState;
    public PlayerFallState fallState;
    public PlayerLandState landState; 
    public PlayerWallSlideState wallSlideState;
    public PlayerWallGrabState wallGrabState;
    public PlayerWallClimbState wallClimbState;
    public PlayerLedgeClimbState ledgeClimbState;
    public PlayerWallJumpState wallJumpState;
    public PlayerDashState dashState;
    
    public PlayerData data;

    public Animator animator;
    public Rigidbody2D rb;
    public Input input;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;

    private float groundCheckRadius = 0.3f;
    private float wallCheckDistance = 0.5f;

    [HideInInspector] public int facingDirection;

    void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, data, "idle");
        moveState = new PlayerMoveState(this, stateMachine, data, "move");
        inAirState = new PlayerInAirState(this, stateMachine, data, "inAir");
        jumpState = new PlayerJumpState(this, stateMachine, data, "inAir");
        fallState = new PlayerFallState(this, stateMachine, data, "fall");
        landState = new PlayerLandState(this, stateMachine, data, "land");
        wallSlideState = new PlayerWallSlideState(this, stateMachine, data, "wallSlide");
        wallGrabState = new PlayerWallGrabState(this, stateMachine, data, "wallGrab");
        wallClimbState = new PlayerWallClimbState(this, stateMachine, data, "wallClimb");
        ledgeClimbState = new PlayerLedgeClimbState(this, stateMachine, data, "ledgeClimbState");
        wallJumpState = new PlayerWallJumpState(this, stateMachine, data, "inAir");
        dashState = new PlayerDashState(this, stateMachine, data, "inAir");
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<Input>();

        facingDirection = 1;

        stateMachine.Init(idleState);
    }

    void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public void SetVelocityX(float velocity)
    {
        rb.velocity = new Vector2(velocity, rb.velocity.y);
    }

    public void SetVelocityY(float velocity)
    {
        rb.velocity = new Vector2(rb.velocity.x, velocity);
    }

    public float GetVelocityY()
    {
        return rb.velocity.y;
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();

        rb.velocity = new Vector2(angle.x * velocity * direction, angle.y * velocity);
    }

    public void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
    }

    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    public bool CheckIfTouchingWall()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, wallCheckDistance, whatIsGround);
    }

    public bool CheckIfTouchingWallBack()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * -1 * facingDirection, wallCheckDistance, whatIsGround);
    }

    public bool CheckIfTouchingLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.right * facingDirection, wallCheckDistance, whatIsGround); 
    }

    public Vector2 DetermineCornerPosition()
    {
        RaycastHit2D xHit = Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, wallCheckDistance, whatIsGround);

        float xDistance = xHit.distance;

        RaycastHit2D yHit = Physics2D.Raycast(ledgeCheck.position + new Vector3(xDistance * facingDirection, 0f, 0f), Vector2.down, ledgeCheck.position.y - wallCheck.position.y, whatIsGround);

        float yDistance = yHit.distance;

        return new Vector2(wallCheck.position.x + xDistance * facingDirection, ledgeCheck.position.y - yDistance);
    }

    public void CheckIfShouldFlip(int x)
    {
        if (x != 0 && x != facingDirection)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void AnimationTrigger() => stateMachine.currentState.AnimationTrigger();

    private void AnimationFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();
}
