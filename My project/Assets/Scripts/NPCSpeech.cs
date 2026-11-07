using UnityEngine;

public class NPCSpeech : MonoBehaviour
{
    [SerializeField] private Transform bubbleAnchor; // transform for the speech bubble to appear.
    [SerializeField] private GameObject bubblePrefab; // the speech bubble prefab reference
    [SerializeField] private SpeechBubble speechScript; // reference to speech script.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speechScript = Instantiate(bubblePrefab, bubbleAnchor).GetComponent<SpeechBubble>();

    }

    [ContextMenu("Speak Cow")]
    public void Interact()
    {
        // TODO:: move this to the interaction function
        speechScript.Show("Moo cow!");

    }
}
