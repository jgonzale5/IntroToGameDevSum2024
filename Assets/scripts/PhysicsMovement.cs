using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    public Rigidbody reggiebody;
    public float speed;
    public float jumpForce;
    public float jumpRaycastDistance = 2f;
    public LayerMask jumpLayers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxisRaw("Horizontal"));

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            Movement(Vector3.right);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            Movement(Vector3.left);
        }

        Debug.Log(CanJump() + " " + Input.GetButtonDown("Jump"));
        if (CanJump() && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Movement(Vector3 direction)
    {
        Vector3 finalVelocity = reggiebody.velocity;

        finalVelocity += direction * speed;

        if (finalVelocity.x > speed)
        {
            finalVelocity.x = speed;
        }
        else if (finalVelocity.x < -speed)
        {
            finalVelocity.x = -speed;
        }

        reggiebody.velocity = finalVelocity;
    }

    private void Jump()
    {
        Debug.Log("jumping");
        reggiebody.AddForce(jumpForce * Vector3.up);
    }

    private bool CanJump()
    {
        RaycastHit hit;
        bool result = Physics.Raycast(this.transform.position, Vector3.down, out hit, jumpRaycastDistance, jumpLayers);
        
        if (result == true)
            Debug.DrawRay(this.transform.position, hit.point - this.transform.position, Color.red);
        else
            Debug.DrawRay(this.transform.position, Vector3.down * jumpRaycastDistance, Color.blue);

        return result;
    }
}
