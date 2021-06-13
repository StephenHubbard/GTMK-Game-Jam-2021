using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private GameObject nextLevelContainer;
    [SerializeField] private GameObject levelCompleteVFX;
    [SerializeField] private AudioSource winLevelSFX;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Instantiate(levelCompleteVFX, transform.position, Quaternion.identity);
            winLevelSFX.Play();
            nextLevelContainer.SetActive(true);
        }
    }
}
