using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [SerializeField] private Input input;

    private bool playerInRange;  

    void Awake()
    {
        visualCue.SetActive(false);

        playerInRange = false;
    }

    void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying && input.GetAction())
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true; 

            visualCue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false; 

            visualCue.SetActive(false);
        }
    }
}
