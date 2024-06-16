using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    //The speed of the ship
    public float xSpeed = 2f;
    public float ySpeed = 2f;
    //The rigidbody of this object
    public Rigidbody rb;

    [Header("Animations")]
    //
    public Animator animator;
    //
    public string xMov_Name = "xMov";
    //
    public string yMov_Name = "yMov";

    // Update is called once per frame
    void Update()
    {
        //Defining a vector to easily represent the velocity of the object
        Vector3 newVelocity = Vector3.zero;

        //The velocity in x and y are the input in each axis multiplied by the speed, in order to get the direction as well 
        newVelocity.x = xSpeed * Input.GetAxis("Horizontal");
        newVelocity.y = ySpeed * Input.GetAxis("Vertical");

        //
        animator.SetInteger(xMov_Name, Mathf.RoundToInt(newVelocity.x));
        //
        animator.SetInteger(yMov_Name, Mathf.RoundToInt(newVelocity.y));

        //The rigidbogy velocidy is updated
        rb.velocity = newVelocity;
    }
}
