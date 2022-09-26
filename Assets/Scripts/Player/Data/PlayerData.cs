using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/PlayerData/BaseData")]
public class PlayerData : ScriptableObject
{
    [Header("Move state")]
    public float moveVelocity = 10f;

    [Header("Jump state")]
    public float jumpVelocity = 15f;

    [Header("Check variables")]
    public float groundCheckRadius = 0.3f;
    public LayerMask whatIsGround;    
}
