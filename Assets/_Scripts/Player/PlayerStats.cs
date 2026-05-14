using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerStats", menuName = "Scriptable Objects Data/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [Header("Movement Stats")]
    [Tooltip("Normal walking speed")] public float walkSpeed = 5f;
    [Tooltip("Normal running speed")] public float runSpeed = 8f;
    [Tooltip("Normal crouching speed")] public float crouchSpeed = 2.5f;
}
