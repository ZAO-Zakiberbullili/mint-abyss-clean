using UnityEngine;

public class DeadMenuAudio : MonoBehaviour
{

    void Awake()
    {
        GameObject.Find("DeadScreen").GetComponent<AudioSource>().Play();

    }

}
