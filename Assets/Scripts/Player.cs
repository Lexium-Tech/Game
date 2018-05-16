using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

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

    // Called when class instance is called
    void Start ()
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


        if(Input.GetKeyDown(KeyCode.W))
        {
            Vector3 playerMove = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            rb.velocity = playerMove * speed;
        }

        // Get movement input
        // float moveHorizontal = Input.GetAxis("Horizontal");
        //  float moveVertical = Input.GetAxis("Vertical");

        //  Vector3 movement = new Vector3(moveHorizontal, 0.0f,moveVertical);

        // Update player

        // Make player rotate with the mouse
        transform.eulerAngles = cam.transform.eulerAngles;
    }
}
