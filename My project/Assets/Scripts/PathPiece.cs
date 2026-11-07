using UnityEngine;

public class PathPiece : MonoBehaviour
{
    public Color litColor = Color.white;
    public Color unlitColor = Color.darkGray;

    private SpriteRenderer sprite;
    private BoxCollider2D blocker;
    private bool isUnlocked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        blocker = GetComponent<BoxCollider2D>();
        sprite.color = unlitColor;
    }

    /// <summary>
    /// This method lights up the game object it is attached to and disables the collider.
    /// The intended use is to light up a pathway to allow the player to "walk onto it" after the call to this method.
    /// </summary>
    public void Unlock()
    {
        if (isUnlocked) return;
        isUnlocked = true;
        sprite.color = litColor;
        blocker.enabled = false;
    }
}
