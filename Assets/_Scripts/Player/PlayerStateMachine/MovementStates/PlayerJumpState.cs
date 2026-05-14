using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(PlayerContext context, PlayerState subState, PlayerState superState) 
        : base(context, subState, superState) { }
}
