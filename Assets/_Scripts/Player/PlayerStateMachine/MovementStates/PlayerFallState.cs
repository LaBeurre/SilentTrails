using UnityEngine;

public class PlayerFallState : PlayerState
{
    public PlayerFallState(PlayerContext context, PlayerState subState, PlayerState superState) 
        : base(context, subState, superState) { }
}
