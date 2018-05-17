using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I can use cool features too
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    // Player rigidbody
    private Rigidbody rb;

    // Camera object for camera to use
    public Camera cam;

    // Speed of player
    public float speed;

    // Private vars used for camera rotation
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Camera movement speed
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    // Used for jumping. If the player is on the ground
    private bool isGrounded;

    // The force of the jump
    public float jumpForce = 2.0f;

    // Called when class instance is called
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Constant update, fixed timer
    void FixedUpdate()
    {
        // Set yaw and pitch from mouse input
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        Vector3 camMovement = new Vector3(pitch, yaw, 0.0f);
        // Update Camera
        cam.transform.eulerAngles = camMovement;


        // Get movement input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        /*
         * First, we get the movement input, next, we set the direction
         * to https://docs.unity3d.com/ScriptReference/Transform.TransformDirection.html.
         * Set y to 0 so he cant uh, fly lol
         */
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = cam.transform.TransformDirection(movement);
        movement.y = 0.0f;

        // Update player
        rb.velocity = movement * speed;

        // Make player rotate with the mouse
        transform.eulerAngles = cam.transform.eulerAngles;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * jumpForce;
        }
    }


    /*
     * When the object holds to the ground, we set that it is grounded 
     */
    void OnCollisionStay()
    {
        isGrounded = true;
    }

}
