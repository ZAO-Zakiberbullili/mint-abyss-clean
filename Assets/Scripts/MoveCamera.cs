using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
    }
}
