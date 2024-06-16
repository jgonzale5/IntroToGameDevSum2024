using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicControl : MonoBehaviour
{
    public float angleSpeed = 30.0f;

    public float speed;
    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, angleSpeed * Time.deltaTime * xInput);
        Movement(transform.forward * zInput);
    }

    private void Movement(Vector3 direction)
    {
        controller.Move(direction * speed * Time.deltaTime);
    }
}
