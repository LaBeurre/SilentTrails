using UnityEngine;

public class PlayerAirborneState : PlayerState
{
    public PlayerAirborneState(PlayerContext context, PlayerState subState, PlayerState superState)
        : base(context, subState, superState) { }
}
