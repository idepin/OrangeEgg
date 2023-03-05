using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    [SerializeField] private string characterTag;
    [SerializeField] private string messageText = "Interact";
    [SerializeField] private InputActionReference interactInput;
    [SerializeField] private UnityEvent onInteract;
    [SerializeField] private bool disableOnInteract;

    private bool onTrigger;

    private void OnEnable()
    {
        interactInput.action.performed += InteractInputHandler;
    }
    private void OnDisable()
    {
        interactInput.action.performed -= InteractInputHandler;
    }
    private void InteractInputHandler(InputAction.CallbackContext ctx)
    {
        if(onTrigger)
        {
            
            onInteract?.Invoke();
            if (disableOnInteract)
            {
                InteractUI.Instance.Hide();
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(characterTag))
        {
            InteractUI.Instance.Show(messageText);
            onTrigger = true;
        }
    }

    

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(characterTag))
        {
            InteractUI.Instance.Hide();
            onTrigger = false;
        }
    }
}
