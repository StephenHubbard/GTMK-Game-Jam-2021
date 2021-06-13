using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Destructible")) {
            Destroy(other.gameObject);
        }
    }
}
