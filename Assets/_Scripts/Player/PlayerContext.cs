using UnityEngine;

/// <summary>
/// Represents the context for a player, providing access to core components and player-related data required for
/// gameplay logic.
/// </summary>
/// <remarks>The PlayerContext class aggregates references to the player's brain, input handler, movement
/// controller, and statistics. It is typically used to coordinate interactions between these components and to maintain
/// player state throughout the game lifecycle.</remarks>
public class PlayerContext
{
    // Components
    public PlayerBrain brain;
    public PlayerInputs inputs;
    public PlayerMovement movement;

    // Stats & Data
    public PlayerStats stats;

    public PlayerContext(PlayerBrain brain, PlayerInputs inputs, PlayerMovement movement, PlayerStats stats)
    {
        this.brain = brain;
        this.inputs = inputs;
        this.movement = movement;
        this.stats = stats;

        this.inputs.Initialize(this);
        this.movement.Initialize(this);
    }
}
