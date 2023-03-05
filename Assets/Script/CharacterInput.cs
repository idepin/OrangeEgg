using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInput : MonoBehaviour
{
    [SerializeField] private InputActionReference verticalInput;
    [SerializeField] private InputActionReference horizontalInput;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 50f;

    private Rigidbody rb;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Mendapatkan input untuk gerakan horizontal dan vertikal
        float moveHorizontal = horizontalInput.action.ReadValue<float>();
        float moveVertical = verticalInput.action.ReadValue<float>();

        // Mendapatkan arah gerakan karakter
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        // Menggerakkan Rigidbody
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);


        Quaternion targetRotation = Quaternion.LookRotation(movement);
        rb.rotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotateSpeed * Time.fixedDeltaTime);
    }
}
