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
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float rotateSpeed = 50f;

    private CharacterAnimator characterAnimator;

    private Rigidbody rb;

    private float speed;
    private float animatorSpeed;

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

            animatorSpeed = 0.5f;
            Vector3 movement = new Vector3(moveVertical, 0, -moveHorizontal);
            rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
            if (movement != Vector3.zero)
            {
                
                Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            }
            if (sprintInput.action.IsPressed())
            {
                animatorSpeed= 1.0f;

                speed = runSpeed;
            }
            else
            {
                speed = moveSpeed;
            }
        }
        else
        {
            animatorSpeed = 0.0f;
        }
        characterAnimator.SetAnimatorSpeed(animatorSpeed);
    }
}