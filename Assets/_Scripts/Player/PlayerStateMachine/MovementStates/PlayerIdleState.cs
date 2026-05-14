using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerContext context, PlayerState subState, PlayerState superState) 
        : base(context, subState, superState) { }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (context.inputs.GetMoveDirectionInput().magnitude > 0)
        {
            RequestStateChange(new PlayerWalkState(context, subState, superState));
        }
    }
}
