using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    [SerializeField] private Sprite normalCursor;
    [SerializeField] private Sprite wandCursor;

    private SpriteRenderer rend;

    private bool isHoveringOverActiveWandObject = false;

    private void Start() {
        Cursor.visible = false;
    }

    private void Update() {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        if (isHoveringOverActiveWandObject) {
            rend.sprite = wandCursor;
        }
        else {
            rend.sprite = normalCursor;
        }
    }
}
