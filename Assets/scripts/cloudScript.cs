using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudScript : MonoBehaviour
{
    //This is the speed at which the cloud is moving
    public float speed = 10.5f;
    //The amount of time that must pass between resets
    public float resetTime = 1f;

    //The starting position of the cloud
    private Vector3 startingPos;
    //Keeps track of how much time has passed since the cloud was in its original position
    private float timePassed = 0;
    //Keeps track of whether the cloud is moving to the right
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
        //The position of the cloud at the start of the game is cache'd
        startingPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //If its moving to the right, move it to the right
        if (movingRight)
        {
            Movement(Vector3.right);
        }
        //Otherwise move it to the left
        else
        {
            Movement(-Vector3.right);
        }

        //The time is added to the time passed counter
        timePassed += Time.deltaTime;

        //If the time passed since the last reset is more or equal than the time between resets...
        if (timePassed >= resetTime)
        {
            //Invert the direction
            movingRight = !movingRight;

            //Set the time passed to 0
            timePassed = 0;
        }
    }

    private void Movement(Vector3 direction)
    {
        /*
        ////Method A
        ////DOES NOT WORK INSIDE THIS FUNCTION
        //Vector3 movement = new Vector3(speed * Time.deltaTime, 0, 0);
        //this.gameObject.transform.position = this.gameObject.transform.position + movement;

        ////Method B
        //Vector3 movement = direction * speed * Time.deltaTime;
        //this.gameObject.transform.position += movement;

        ////Method C
        //Vector3 movement = this.gameObject.transform.position + (direction * speed * Time.deltaTime);
        //this.gameObject.transform.position = movement;

        //Method D
        */
        //Makes a new vector with the position of the object
        Vector3 finalPosition = this.gameObject.transform.position;
        //Adds to the position of the object the speed for this frame in the desired direction
        finalPosition += direction * speed * Time.deltaTime;
        //Set the final position to the result
        this.gameObject.transform.position = finalPosition;
    }
}
