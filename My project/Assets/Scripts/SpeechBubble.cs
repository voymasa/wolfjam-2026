using UnityEngine;
using TMPro;

[RequireComponent(typeof(SpriteRenderer))]
public class SpeechBubble : MonoBehaviour
{
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private TextMeshPro text;
    [SerializeField] private float duration = 2.0f; // how long in seconds that the bubble lasts before auto closing
    [SerializeField] private Vector2 padding = new Vector2(0.5f, 0.3f);

    void Start()
    {
        background = GetComponent<SpriteRenderer>();
    }

    public void Show(string phrase)
    {
        text.text = phrase;
        text.ForceMeshUpdate();

        // Auto-size background to fit text
        Vector2 textSize = text.GetRenderedValues(false);
        background.size = textSize + padding;
        background.transform.localPosition = new Vector3(0, -background.size.y / 2f, 0);

        // Pop-in animation
        transform.localScale = Vector3.zero;
        StartCoroutine(PopIn());
    }

    /// <summary>
    /// This method result in the bubble appearing to pop-in by growing to full size.
    /// </summary>
    /// <returns></returns>
    private System.Collections.IEnumerator PopIn()
    {
        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime * 8.0f;
            transform.localScale = Vector3.one * Mathf.Clamp01(t);
            yield return null; // waits to finish and return a null
        }

        // timer before disappearing
        yield return new WaitForSeconds(duration);

        // go away
        t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime * 8f;
            transform.localScale = Vector3.one * Mathf.Clamp01(t);
            yield return null;
        }
    }
}