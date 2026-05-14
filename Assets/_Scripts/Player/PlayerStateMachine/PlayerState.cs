using UnityEngine;

public abstract class PlayerState
{
    protected PlayerContext context;
    protected bool isRootState;
    protected PlayerState superState; // or parent state
    protected PlayerState subState; // or child state

    public PlayerState SuperState => superState;
    public PlayerState SubState => subState;

    public PlayerState(PlayerContext context, PlayerState subState, PlayerState superState) 
    {  
        this.context = context;

        if (subState != null)
        {
            this.subState = subState;
            this.subState.superState = this;
            this.subState.isRootState = false;
        }
            
        this.superState = superState;

        if (superState == null) isRootState = true;
        else isRootState = false;
    }

    public virtual void Enter()
    {
        if (context == null) return;

        if (subState != null) subState.Enter();
    }

    public virtual void Update() 
    {
        if (context == null) return;

        if (subState != null) subState.Update();
    }

    public virtual void FixedUpdate()
    {
        if (context == null) return;

        if (subState != null) subState.FixedUpdate();
    }

    public virtual void Exit() 
    {
        if (context == null) return;

        if (subState != null) subState.Exit();
    }

    protected void RequestStateChange(PlayerState newState)
    {
        if (context == null) return;
        if (newState == null) return;

        // Check if the current state is a root state
        if (!isRootState)
        {
            // If it's not a root state, delegate the state change request to the super state
            superState.OnSubStateChangeRequested(newState);
            return;
        }

        // Refer to the brain to request transition to the new state
        context.brain.OnStateChangeRequested(newState);
    }

    protected void OnSubStateChangeRequested(PlayerState newSubState)
    {
        if (context == null) return;
        if (newSubState == null) return;

        ChangeSubState(newSubState);
    }

    public void SetSuperState(PlayerState newSuperState)
    {
        if (context == null) return;
        if (newSuperState == null) return;

        superState = newSuperState;

        OnStateModified();
    }

    protected void ChangeSubState(PlayerState newSubState)
    {
        if (context == null) return;
        if (newSubState == null) return;

        subState?.Exit(); // Exit current sub-state if it exists

        Debug.Log($"Sub-state change requested: {subState?.GetType().Name} -> {newSubState.GetType().Name}");
        newSubState.superState = this;
        subState = newSubState;
        subState.isRootState = false;

        subState.Enter(); // Enter the new sub-state

        OnStateModified();
    }

    private void OnStateModified()
    {
        context?.brain?.UpdateLogState();
    }
}
