using System;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterAnimator))]
public class CharacterInput : MonoBehaviour
{
    
    [SerializeField] private InputActionReference verticalInput;
    [SerializeField] private InputActionReference horizontalInput;
    [SerializeField] private InputActionReference sprintInput;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 50f;
    private CharacterAnimator characterAnimator;

    private Rigidbody rb;
    private Vector3 moveDirection = Vector3.zero;

    private float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterAnimator = GetComponent<CharacterAnimator>();
    }

    private void FixedUpdate()
    {
        if (horizontalInput.action.IsPressed() || verticalInput.action.IsPressed())
        {
            float moveHorizontal = horizontalInput.action.ReadValue<float>();
            float moveVertical = verticalInput.action.ReadValue<float>();

            speed = 0.5f;

            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            if (movement != Vector3.zero)
            {
                transform.LookAt(transform.position + movement);
            }
            if (sprintInput.action.IsPressed())
            {
                speed= 1.0f;
            }
        }
        characterAnimator.SetAnimatorSpeed(speed);
    }
}