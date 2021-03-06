using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private float springForce = 400f;
    [SerializeField] private AudioSource springSFX;

    private Animator myAnimator;

    private void Awake() {
        myAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Active")) {
            springSFX.Play();
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, springForce));
            myAnimator.SetTrigger("Bounce");
        }
    }
}
