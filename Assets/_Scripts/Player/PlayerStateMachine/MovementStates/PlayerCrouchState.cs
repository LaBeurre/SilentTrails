using UnityEngine;

public class PlayerCrouchState : PlayerState
{
    public PlayerCrouchState(PlayerContext context, PlayerState subState, PlayerState superState) 
        : base(context, subState, superState) { }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (!context.inputs.GetCrouchInput() || context.inputs.GetRunInput())
        {
            RequestStateChange(new PlayerStandState(context, subState, superState));
        }
    }
}
