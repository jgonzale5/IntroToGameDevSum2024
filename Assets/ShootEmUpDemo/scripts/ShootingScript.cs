using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    //The game object that determines where projectiles are spawned and what their spawning rotation is
    public Transform muzzle;

    //The prefab that is spawned when you click
    public Transform projectilePrefab;

    //
    public ParticleSystem muzzleFlash;

    [Header("Shaking")]
    //
    public CameraShake shakingScript;
    //
    public float shakeDuration;
    //
    public float shakeIntensity;

    [Header("Sounds")]
    //
    public AudioSource audioSource;
    //
    public AudioClip shootingSound;

    void Update()
    {
        //When the player clicks...
        if (Input.GetButtonDown("Fire1"))
        {
            //Instantiate a projectile at the position of the muzzle, with the same rotation as it.
            Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);

            //
            muzzleFlash.Play();
            //
            shakingScript.ShakeCamera(shakeDuration, shakeIntensity);

            //
            audioSource.PlayOneShot(shootingSound);
        }
    }
}
