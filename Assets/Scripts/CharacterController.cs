using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Orientation { Forward, Backward, Left, Right, None }

public class CharacterController : MonoBehaviour
{
    
    public Orientation controlsOrientation;

    public float accelleration = 100;
    public float maxSpeed = 2;
    public float JumpHeight = 3;

    public float MouseSpeed = 3;


    private Rigidbody rb;
    private Vector3 movement;
    private Vector2 XYmovement;
    private float Jump;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveVert = Input.GetAxis("Vertical");
        float moveHor = Input.GetAxis("Horizontal");

        XYmovement = new Vector2(rb.velocity.x, rb.velocity.z);

        if (XYmovement.magnitude > maxSpeed)// clamping speed to max speed
        {
            XYmovement = XYmovement.normalized * maxSpeed;
            rb.velocity = new Vector3(XYmovement.x, rb.velocity.y, XYmovement.y);
        }

        if (controlsOrientation == Orientation.Forward)
        {
            movement = new Vector3(-moveHor, Jump, -moveVert);
        }
        else if (controlsOrientation == Orientation.Backward)
        {
            movement = new Vector3(moveHor, Jump, moveVert);
        }
        else if (controlsOrientation == Orientation.Left)
        {
            movement = new Vector3(-moveVert, Jump, moveHor);
        }
        else if (controlsOrientation == Orientation.Right)
        {
            movement = new Vector3(moveVert, Jump, -moveHor);
        }
        else if (controlsOrientation == Orientation.None)
        {
            movement = Vector3.zero;
        }

        //movement = transform.TransformDirection(movement); // <-- Change Force from Global to Local

        rb.AddForce(movement * accelleration);

        Jump = 0f;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump = JumpHeight;
        }
    }
}