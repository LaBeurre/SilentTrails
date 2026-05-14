using UnityEngine;

public class PlayerWalkState : PlayerState
{
    private Vector2 moveInput;

    public PlayerWalkState(PlayerContext context, PlayerState subState, PlayerState superState) 
        : base(context, subState, superState) { }

    public override void Enter()
    {
        base.Enter();

        if (context.brain.IsInState<PlayerCrouchState>())
            context.movement.SetMovementSpeed(context.stats.crouchSpeed);
        else
            context.movement.SetMovementSpeed(context.stats.walkSpeed);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        moveInput = context.inputs.GetMoveDirectionInput();

        if (moveInput.magnitude == 0)
        {
            RequestStateChange(new PlayerIdleState(context, subState, superState));
        }
        else if (context.inputs.GetRunInput())
        {
            if (context.brain.IsInState<PlayerCrouchState>())
            {
                // If the player tries to run while crouching, ignore the input (let the crouch state handle it)
            }
            else
                RequestStateChange(new PlayerRunState(context, subState, superState));
        }

        context.movement.Move(moveInput);
    }
}
