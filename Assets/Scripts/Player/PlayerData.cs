using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("Characteristics")]
    public float moveVelocity;
    public float jumpVelocity;
    public float jumpHeightMultiplier;
    public float wallClimbVelocity;
    public float wallSlideVelocity;
    public float wallJumpVelocity;

    [Header("Abilities")]
    public int amountOfJumps;
    public float coyoteTime;
    public float wallJumpTime;
    public Vector2 wallJumpAngle;
}
