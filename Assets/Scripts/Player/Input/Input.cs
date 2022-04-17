using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public int x;

    public int y;

    public bool jump;

    public bool grab;

    public bool dash;

    public bool jumpStop;

    public bool dashStop;

    private float inputHoldTime = 0.2f;

    private float jumpStartTime;

    private float dashStartTime;

    void Update()
    {
        CheckJumpInputHoldTime();
        CheckDashInputHoldTime();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();

        x = (int)(move * Vector2.right).normalized.x;
        y = (int)(move * Vector2.up).normalized.y;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jump = true;
            jumpStop = false;
            jumpStartTime = Time.time;
        }

        if (context.canceled)
        {
            jumpStop = true;
        }
    }

    public void UseJumpInput()
    {
        jump = false;
    }

    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpStartTime + inputHoldTime)
        {
            jump = false;
        }
    }

    public void OnGrab(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            grab = true;
        }

        if (context.canceled)
        {
            grab = false;
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            dash = true;
            dashStop = false;
            dashStartTime = Time.time;
        }

        if (context.canceled)
        {
            dashStop = true;
        }
    }

    public void UseDashInput()
    { 
        dash = false;
    }

    private void CheckDashInputHoldTime()
    {
        if (Time.time >= dashStartTime + inputHoldTime)
        {
            dash = false;
        }
    }

    // add buttons for dialogues

    public void OnAction(InputAction.CallbackContext context) { }
}
