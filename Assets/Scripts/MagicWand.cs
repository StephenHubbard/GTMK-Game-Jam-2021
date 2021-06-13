using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWand : MonoBehaviour
{
    [SerializeField] private GameObject lightWorld;
    [SerializeField] private GameObject darkWorld;
    [SerializeField] private GameObject betweenWorlds;
    [SerializeField] private Transform vfxSpawnPoint;
    [SerializeField] private GameObject wandVFX;

    [SerializeField] private AudioSource wandSFX;

    public GameObject heldGameObject;
    private CharacterController2D characterController2D;

    private GameObject wandEffect;

    private void Awake() {
        characterController2D = FindObjectOfType<PlayerMovement>().GetComponent<CharacterController2D>();
    }

    private void Update() {
    }

    public void SetHeldGameObject(GameObject go) {
        heldGameObject = go;
        heldGameObject.transform.parent = betweenWorlds.transform;
        wandEffect = Instantiate(wandVFX, vfxSpawnPoint.position, transform.rotation);
        wandEffect.transform.parent = gameObject.transform;

        if (!characterController2D.m_FacingRight) {
            var particleShape = wandEffect.GetComponent<ParticleSystem>().shape;
            particleShape.alignToDirection = true;
        }

        WandSound();
    }

    private void WandSound() {
        wandSFX.Play();
    }

    public void WandRelease() {
        if (lightWorld.activeInHierarchy) {
            heldGameObject.transform.parent = lightWorld.transform;
        }
        else {
            heldGameObject.transform.parent = darkWorld.transform;
        }

        wandSFX.Stop();
        heldGameObject = null;
        Destroy(wandEffect);
    }

    public void DestroyWandEffect() {
        wandSFX.Stop();
        Destroy(wandEffect);
    }
}
