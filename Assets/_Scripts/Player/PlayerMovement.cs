using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerContext context;

    [Header("Debugging")]
    [SerializeField] private bool showDebug = true;
    [SerializeField] private float currentSpeed;
    [SerializeField] private Vector2 currentMoveInput;

    public void Initialize(PlayerContext context)
    {
        this.context = context;
    }

    public void SetUpMovement()
    {
        currentSpeed = context.stats.walkSpeed;
    }

    public void SetMovementSpeed(float speed) { currentSpeed = speed; }

    //private void FixedUpdate()
    //{
    //    currentMoveInput = context.inputs.GetMoveDirectionInput().normalized;
    //    if (currentMoveInput.magnitude == 0)
    //    {
    //        return;
    //    }

    //    Move(currentMoveInput);
    //}

    public void Move(Vector2 moveInput)
    {
        transform.Translate(moveInput * currentSpeed * Time.fixedDeltaTime, Space.World);
    }
}
