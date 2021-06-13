using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour

{
    private Rigidbody2D rb;
    private Collider2D myCollider;
    private bool isPickedUp = false;
    private float startPosx;
    private float startPosy;


    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }

    private void Update() {
        RotateObject();
        MoveObjectBeingDragged();
    }

    private void MoveObjectBeingDragged() {
        if (isPickedUp) {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosx, mousePos.y - startPosy, 0);
        }
    }

    private void RotateObject() {
        if (isPickedUp == false) { return; }

        transform.Rotate(0f, 0f, 30f * Time.deltaTime, Space.Self);
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) {
            FindObjectOfType<MagicWand>().SetHeldGameObject(gameObject);
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            startPosx = mousePos.x - this.transform.localPosition.x;
            startPosy = mousePos.y - this.transform.localPosition.y;
            isPickedUp = true;
            myCollider.enabled = false;

            CheckIfBomb();
        }
    }

    void OnMouseUp() {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector3(mousePos.x - startPosx, mousePos.y - startPosy, 0);
        FindObjectOfType<MagicWand>().WandRelease();
        rb.velocity = new Vector2(0f, 0f);
        myCollider.enabled = true;
        isPickedUp = false;
    }

    private void CheckIfBomb() {
        if (!gameObject.GetComponent<Bomb>()) { return; }

        gameObject.GetComponent<Bomb>().StartBombTimer();
    }
}