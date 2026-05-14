using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    /// <summary>
    /// Default root state for the player when initialized. This state represents the player being on the ground and is responsible for handling all grounded-related logic, such as movement, jumping, and interactions with the environment. It serves as the parent state from which all other grounded sub-states (e.g., walking, running, idle) will derive and manage their specific behaviors while the player is grounded.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="subState"></param>
    /// <param name="superState"></param>
    public PlayerGroundedState(PlayerContext context, PlayerState subState, PlayerState superState) 
        : base(context, subState, superState) 
    {
        if (subState == null)
        {
            // If no sub-state is provided, initialize with a default grounded idle standing state
            subState = new PlayerStandState(context, new PlayerIdleState(context, null, null), this);
            ChangeSubState(subState);
        }
    }
}
