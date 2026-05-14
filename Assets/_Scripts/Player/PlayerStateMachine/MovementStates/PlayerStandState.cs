using UnityEngine;

public class PlayerStandState : PlayerState
{
    public PlayerStandState(PlayerContext context, PlayerState subState, PlayerState superState) 
        : base(context, subState, superState) { }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (context.inputs.GetCrouchInput() && !context.inputs.GetRunInput())
        {
            RequestStateChange(new PlayerCrouchState(context, subState, superState));
        }
    }
}
