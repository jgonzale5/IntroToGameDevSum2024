using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    //The game object that will be disabled when this object gets hit
    public GameObject balloonObject;
    //The time it takes a balloon to respawn after it has been destroyed
    public float respawnTime = 5;
    //The particle effect that will be spawned when the balloon pops
    public Transform poppingEffect;

    [Header("Shaking")]
    //The duration of the shake
    public float shakeDuration = 0.1f;
    //The intensity of the shake in Unity units
    public float shakeIntensity = 1f;

    [Header("Animations")]
    //The animator that controls the animations on the balloon
    public Animator animator;
    //The name of the trigger parameter that tells the balloon to play its spawn animation
    public string spawnParameterName = "Spawn";

    [Header("Sounds")]
    //The audiosource that plays the balloon sounds
    public AudioSource source;
    //The clip that will play when the balloon is popped
    public AudioClip popSound;



    //Keeps track of whether the balloon is popped
    private bool popped = false;
    //The time passed since the last spawn/respawn
    private float respawnTimeCount = 0;

    //Every frame...
    private void Update()
    {
        //Call the function to check if the balloon needs to be respawned and do so if applicable
        BalloonRespawning();
    }

    //When any object enters this trigger (or when this object enters any trigger)
    public void OnTriggerEnter(Collider other)
    {
        //Destroy the other object
        Destroy(other.gameObject);

        //Pop the balloon
        PopBalloon();
    }

    private void BalloonRespawning()
    {
        //If the balloon is popped, we don't need to do anything 
        if (!popped)
            return;

        //If enough time has passed
        if (respawnTimeCount >= respawnTime)
        {
            //The balloon is enabled again
            balloonObject.SetActive(true);
            //The balloon is marked as popped
            popped = false;
            //The time for respawn is reset
            respawnTimeCount = 0;

            //Trigger the spawn animation on the balloon by setting the trigger on
            animator.SetTrigger(spawnParameterName);
        }
        //Otherwise
        else
        {
            //We add time to the time-keeping variable
            respawnTimeCount += Time.deltaTime;
        }
    }

    //This function is called to pop the balloon
    public void PopBalloon()
    {
        //Disable the balloon
        balloonObject.SetActive(false);
        //Mark this balloon as popped
        popped = true;

        //Spawn the popping particle effect at the position of the collider (you could modify it so it's the position of the mesh), with no rotation
        Instantiate(poppingEffect, this.transform.position, Quaternion.identity);

        //Tell the camera to shake
        CameraShake.instance.ShakeCamera(shakeDuration, shakeIntensity);

        //Play the popping sound
        PlayPopSound();
    }
    
    //Plays the popping sound when called
    private void PlayPopSound()
    {
        //Tells the audiosource to play the specified audio clip once
        source.PlayOneShot(popSound);
    }

    //Used to test animation events.
    public void DebugAnimationEvent()
    {
        Debug.Log("Boop.");
    }
}
