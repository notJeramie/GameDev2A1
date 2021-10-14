using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float gravity = -9.81f;
    public float moveSpeed = 12f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;
    public float sprintSpeed = 1;

    public LayerMask groundMask;

    public Transform groundCheck;

    public Vector3 velocity;

    bool isGrounded;

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKey("left shift"))
        {
            sprintSpeed = 1.5f;
        }
        else
        {
            sprintSpeed = 1f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * sprintSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
