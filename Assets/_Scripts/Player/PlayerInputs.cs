using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private PlayerContext context;

    public void Initialize(PlayerContext context)
    {
        this.context = context;
    }

    public void SetUpInputs()
    {

    }

    public Vector2 GetMoveDirectionInput()
    {
        Vector2 input = InputSystem.actions["Move"].ReadValue<Vector2>();
        // Null the y value since it's not top-down movement
        input.y = 0;
        return input.normalized;
    }

    public bool GetCrouchInput()
    {
        return InputSystem.actions["Crouch"].IsPressed();
    }

    public bool GetRunInput()
    {
        return InputSystem.actions["Sprint"].IsPressed();
    }

    public bool GetJumpInput()
    {
        return InputSystem.actions["Jump"].IsPressed();
    }
}
