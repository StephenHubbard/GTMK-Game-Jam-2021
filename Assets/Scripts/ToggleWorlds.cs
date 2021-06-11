using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWorlds : MonoBehaviour
{
    [SerializeField] private GameObject lightWorld;
    [SerializeField] private GameObject darkWorld;

    void Start()
    {
        
    }

    void Update()
    {
        ToggleWorld();
    }

    private void ToggleWorld() {
        if (Input.GetMouseButtonDown(1)) {
            if (lightWorld.gameObject.activeInHierarchy) {
                lightWorld.gameObject.SetActive(false);
                darkWorld.gameObject.SetActive(true);
            }
            else if (!lightWorld.gameObject.activeInHierarchy) {
                lightWorld.gameObject.SetActive(true);
                darkWorld.gameObject.SetActive(false);
            }
        }
    }
}
