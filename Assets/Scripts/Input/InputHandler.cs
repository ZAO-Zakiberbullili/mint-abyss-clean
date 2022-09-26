using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public Vector2 Move { get; private set; }

    public int NormInputX { get; private set; }

    public bool Jump { get; private set; }

    public void OnMove(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>();

        NormInputX = (int)(Move * Vector2.right).normalized.x;
    }

    public void OnJump(InputAction.CallbackContext context) 
    { 
        if (context.started)
        {
            Jump = true;
        }
    }

    public void UseJumpInput()
    {
        Jump = false;
    }
}
