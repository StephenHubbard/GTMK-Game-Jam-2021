using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    public float offset;
    private CharacterController2D characterController2D;

    private void Awake() {
        characterController2D = FindObjectOfType<PlayerMovement>().GetComponent<CharacterController2D>();
    }

    private void Update() {
        MouseFollow();
    }

    private void MouseFollow()
    {
        if (characterController2D.m_FacingRight)
        {
        offset = 0f;
        }
        else
        {
        offset = 180f;
        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
}
