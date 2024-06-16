using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    //The game object that determines where projectiles are spawned and what their spawning rotation is
    public Transform muzzle;

    //The prefab that is spawned when you click
    public Transform projectilePrefab;

    //The particle effect representing the muzzle flash
    public ParticleSystem muzzleFlash;

    [Header("Shaking")]
    //A reference to the CameraShake script
    public CameraShake shakingScript;
    //The duration of the shake when the gun is shot
    public float shakeDuration;
    //The intensity of the shake when the gun is shot
    public float shakeIntensity;

    [Header("Sounds")]
    //The audiosource that plays the shooting sound
    public AudioSource audioSource;
    //The sound played when the gun is shot
    public AudioClip shootingSound;

    //Every frame...
    void Update()
    {
        //When the player clicks...
        if (Input.GetButtonDown("Fire1"))
        {
            //Instantiate a projectile at the position of the muzzle, with the same rotation as it.
            Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);

            //Play the muzzle flash particle effect
            muzzleFlash.Play();
            //Shake the camera by the specified duration and intensity
            shakingScript.ShakeCamera(shakeDuration, shakeIntensity);

            //Tells the specified audiosource to play once the specified shooting sound
            audioSource.PlayOneShot(shootingSound);
        }
    }
}
