using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterAnimator))]

public class CharacterController : MonoBehaviour
{
    [SerializeField] private InputActionReference verticalInput;
    [SerializeField] private InputActionReference horizontalInput;
    [SerializeField] private InputActionReference sprintInput;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float walkSpeed = 5.0f;
    [SerializeField] private float runSpeed = 10.0f;
    [SerializeField] private float turnSpeed = 5.0f;

    private CharacterAnimator characterAnimator;

    private Vector3 input;

    private float animatorSpeed = 0.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterAnimator = GetComponent<CharacterAnimator>();
    }

    private void Update()
    {
        GatherInput();
        Look();
        UpdateAnimatorSpeed();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void GatherInput()
    {
        input = new Vector3(horizontalInput.action.ReadValue<float>(), 0, verticalInput.action.ReadValue<float>());
    }

    void Look()
    {
        if (input != Vector3.zero)
        {
            var relative = (transform.position + input.ToIso()) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }
    }

    void Move()
    {
        float currentSpeed = sprintInput.action.ReadValue<float>() > 0 ? runSpeed : walkSpeed;
        rb.MovePosition(transform.position + (transform.forward * input.magnitude) * currentSpeed * Time.deltaTime);
    }

    void UpdateAnimatorSpeed()
    {
        if (input.magnitude > 0)
        {
            animatorSpeed = sprintInput.action.ReadValue<float>() > 0 ? 1.0f : 0.5f;
        }
        else
        {
            animatorSpeed = 0.0f;
        }

        characterAnimator.SetAnimatorSpeed(animatorSpeed);
    }
}
