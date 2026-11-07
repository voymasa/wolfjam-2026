using UnityEngine;

public class NPCSpeech : MonoBehaviour
{
    [SerializeField] private Transform bubbleAnchor; // transform for the speech bubble to appear.
    [SerializeField] private GameObject bubblePrefab; // the speech bubble prefab reference
    [SerializeField] private SpeechBubble speechScript; // reference to speech script.

    [SerializeField] private GameObject pathPiece; // reference to the piece of path to unlock.
    [SerializeField] private PathPiece pathScript; // reference to the path piece script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speechScript = Instantiate(bubblePrefab, bubbleAnchor).GetComponent<SpeechBubble>();
        pathScript = pathPiece.GetComponent<PathPiece>();
    }

    [ContextMenu("Speak Cow")]
    public void Interact()
    {
        speechScript.Show("Moo cow!");

        pathScript.Unlock();
    }
}
