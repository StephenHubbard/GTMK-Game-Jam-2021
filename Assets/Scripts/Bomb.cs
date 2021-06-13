using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject bombExplosionVFX;

    public void StartBombTimer() {
        GetComponent<Animator>().SetTrigger("StartExplosion");
    }

    public void BlowUp() {
        Instantiate(bombExplosionVFX, transform.position, Quaternion.identity);
        FindObjectOfType<MagicWand>().DestroyWandEffect();
        Destroy(gameObject);
    }
}
