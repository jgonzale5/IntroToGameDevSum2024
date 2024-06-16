using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    //The game object that will be disabled when this object gets hit
    public GameObject balloonObject;
    //The time it takes a balloon to respawn after it has been destroyed
    public float respawnTime = 5;
    //
    public Transform poppingEffect;

    [Header("Shaking")]
    //
    public float shakeDuration = 0.1f;
    //
    public float shakeIntensity = 1f;

    [Header("Animations")]
    //
    public Animator animator;
    //
    public string spawnParameterName = "Spawn";

    [Header("Sounds")]
    //
    public AudioSource source;
    //
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

            //
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

        //
        Instantiate(poppingEffect, this.transform.position, Quaternion.identity);
        //
        CameraShake.instance.ShakeCamera(shakeDuration, shakeIntensity);

        PlayPopSound();
    }
    
    //
    private void PlayPopSound()
    {
        //
        source.PlayOneShot(popSound);
    }

    //
    public void DebugAnimationEvent()
    {
        Debug.Log("Boop.");
    }
}
