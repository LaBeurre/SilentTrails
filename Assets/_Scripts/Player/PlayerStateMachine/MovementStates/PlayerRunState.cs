using UnityEngine;

public class PlayerRunState : PlayerState
{
    private Vector2 moveInput;

    public PlayerRunState(PlayerContext context, PlayerState subState, PlayerState superState) 
        : base(context, subState, superState) { }

    public override void Enter()
    {
        base.Enter();

        context.movement.SetMovementSpeed(context.stats.runSpeed);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        moveInput = context.inputs.GetMoveDirectionInput();

        if (moveInput.magnitude == 0)
        {
            RequestStateChange(new PlayerIdleState(context, subState, superState));
        }
        else if (!context.inputs.GetRunInput())
        {
            RequestStateChange(new PlayerWalkState(context, subState, superState));
        }

        context.movement.Move(moveInput);
    }
}
