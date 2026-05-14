using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBrain : MonoBehaviour
{
    private PlayerContext context;
    private PlayerState currentPlayerState;

    [Header("Player States Debugging")]
    [SerializeField] private List<string> currentStateLog = new List<string>();

    [Header("Player Data Assignment")]
    [SerializeField] private PlayerStats stats;

    public PlayerContext Context => context;

    private void Awake()
    {
        InitializePlayer();
        SetUpPlayer();
    }

    public void InitializePlayer()
    {
        PlayerBrain brain = this;
        PlayerInputs inputs = GetComponent<PlayerInputs>();
        PlayerMovement movement = GetComponent<PlayerMovement>();

        context = new PlayerContext(brain, inputs, movement, stats);

        ChangeState(new PlayerGroundedState(context, null, null));
    }

    public void SetUpPlayer()
    {
        context.inputs.SetUpInputs();
        context.movement.SetUpMovement();
    }

    private void Update()
    {
        currentPlayerState.Update();
    }

    private void FixedUpdate()
    {
        currentPlayerState.FixedUpdate();
    }

    public bool IsInState<T>() where T : PlayerState
    {
        PlayerState stateToCheck = currentPlayerState;
        while (stateToCheck != null)
        {
            if (stateToCheck is T) return true;
            stateToCheck = stateToCheck.SubState;
        }
        return false;
    }

    private void ChangeState(PlayerState newState)
    {
        if (newState == null)
        {
            Debug.Log("Attempted to change to a null state. State change aborted.");
            return;
        }

        // Exit the current state
        currentPlayerState?.Exit();

        // Change to the new state
        Debug.Log($"State change requested: {currentPlayerState?.GetType().Name} -> {newState.GetType().Name}");
        currentPlayerState = newState;

        // Enter the new state
        currentPlayerState.Enter();

        // Update the state log for debugging purposes
        UpdateLogState();
    }

    public void OnStateChangeRequested(PlayerState newState)
    {
        // Check if the requested state is the same as the current state
        if (newState == currentPlayerState) return;

        ChangeState(newState);
    }

    public void UpdateLogState()
    {
        // Clear the previous state log
        currentStateLog.Clear();

        // Add the root state
        if (currentPlayerState != null)
            currentStateLog.Add(currentPlayerState.GetType().Name);
        else return;

        PlayerState currentSubState = currentPlayerState.SubState;
        // Check if the current state has a sub-state and add it to the log
        // and repeat until no more sub-states are found
    repeat:
        if (currentSubState != null)
        {
            currentStateLog.Add(currentSubState.GetType().Name);
            currentSubState = currentSubState.SubState;
            goto repeat;
        }
    }
}
