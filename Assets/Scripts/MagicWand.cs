﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWand : MonoBehaviour
{
    [SerializeField] private GameObject lightWorld;
    [SerializeField] private GameObject darkWorld;
    [SerializeField] private GameObject betweenWorlds;

    // public float offset;

    private GameObject heldGameObject;
    private CharacterController2D characterController2D;

    private void Awake() {
        characterController2D = FindObjectOfType<PlayerMovement>().GetComponent<CharacterController2D>();
    }

    private void Update() {
        // FollowMouse();
    }

    public void SetHeldGameObject(GameObject go) {
        heldGameObject = go;
        heldGameObject.transform.parent = betweenWorlds.transform;
    }

    public void WandRelease() {
        if (lightWorld.activeInHierarchy) {
            heldGameObject.transform.parent = lightWorld.transform;
        }
        else {
            heldGameObject.transform.parent = darkWorld.transform;
        }
    }

    // private void FollowMouse()
    // {
    //     if (characterController2D.m_FacingRight)
    //     {
    //     offset = 0f;
    //     }
    //     else
    //     {
    //     offset = 180f;
    //     }

    //     Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    //     float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    //     transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

    // }
}
