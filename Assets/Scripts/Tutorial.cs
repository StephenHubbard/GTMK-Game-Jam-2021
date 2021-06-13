using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorialWindows;
    private int currentIndex = 0;

    public void NextWindow() {

        currentIndex++;

        for (int i = 0; i < tutorialWindows.Length; i++)
        {
            if (i == currentIndex) {
                tutorialWindows[i].SetActive(true);
            }
            else {
                tutorialWindows[i].SetActive(false);
            }
        }
    }

    private void Update() {
        if (currentIndex >= 3) {
            gameObject.SetActive(false);
        }
    }
}
