using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField]
    private float speed = 12f;
    private float gravity = -9.81f;
    private Vector3 velocity;

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundMask;
    private float groundDistance = 0.4f;
    [SerializeField]
    private int jumpHeight = 1;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        Fall();
        Jump();
        Move();
    }

    private void Fall()
    {
        if (isGrounded && velocity.y < 0)
            velocity.y = 0;

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void Move()
    {
        Vector3 x = transform.right * Input.GetAxis("Horizontal");
        Vector3 z = transform.forward * Input.GetAxis("Vertical");

        controller.Move((x + z) * speed * Time.deltaTime);
    }
}
