using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0f) + offset;
    }
}
