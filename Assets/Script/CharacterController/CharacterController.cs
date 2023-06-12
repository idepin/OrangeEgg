using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterAnimator))]
public class CharacterController : MonoBehaviour
{
    #region Fields

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

    private const float AnimatorSpeedFull = 1.0f;

    private const float AnimatorSpeedHalf = 0.5f;

    private const float AnimatorSpeedZero = 0.0f;

    #endregion

    #region Methods

    private void GatherInput()
    {
        input = new Vector3(horizontalInput.action.ReadValue<float>(), 0, verticalInput.action.ReadValue<float>());
    }

    private void Look()
    {
        if (input == Vector3.zero) return;

        var cachePosition = transform.position;
        var relative = cachePosition + input.ToIso() - cachePosition;
        var rot = Quaternion.LookRotation(relative, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        float currentSpeed = sprintInput.action.ReadValue<float>() > 0 
            ? runSpeed 
            : walkSpeed;
        Transform cacheTransform = transform;
        rb.MovePosition(cacheTransform.position + cacheTransform.forward * (input.magnitude * currentSpeed * Time.deltaTime));
    }

    private void UpdateAnimatorSpeed()
    {
        animatorSpeed = input.magnitude > 0 
            ? sprintInput.action.ReadValue<float>() > 0 
                ? AnimatorSpeedFull 
                : AnimatorSpeedHalf 
            : AnimatorSpeedZero;

        characterAnimator.SetAnimatorSpeed(animatorSpeed);
    }

    #endregion

    #region Build-in Methods

    private void Awake()
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

    #endregion
}