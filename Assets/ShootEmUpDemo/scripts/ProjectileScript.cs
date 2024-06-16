using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    //The speed of this projectile
    public float speed = 2f;
    //How long the projectile takes to self-destruct to save memory
    public float lifetime = 10f;

    //A counter to decide when to destroy this object
    private float timePassed = 0f;

    // Update is called once per frame
    void Update()
    {
        //Move the projectile in the forward direction the amount corresponding to this frame.
        transform.position += transform.forward * speed * Time.deltaTime;
        

        //If the lifetime time has passed
        if (timePassed >= lifetime)
        {
            //This projectile is destroyed
            Destroy(this.gameObject);
        }
        //Otherwise
        else
        {
            //Time passed is updated
            timePassed += Time.deltaTime;
        }
    }
}
