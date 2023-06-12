using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    #region Fields

    [SerializeField] private string characterTag;
    
    [SerializeField] private string messageText = "Interact";
    
    [SerializeField] private InputActionReference interactInput;
    
    [SerializeField] private UnityEvent onInteract;
    
    [SerializeField] private bool disableOnInteract;
    
    private bool onTrigger;

    #endregion

    #region Methods

    private void InteractInputHandler(InputAction.CallbackContext ctx)
    {
        if (!onTrigger) return;
        
        onInteract?.Invoke();
        if (!disableOnInteract) return;
        
        InteractUI.Instance.Hide();
        gameObject.SetActive(false);
    }

    #endregion

    #region Methods

    private void OnEnable()
    {
        interactInput.action.performed += InteractInputHandler;
    }
    private void OnDisable()
    {
        interactInput.action.performed -= InteractInputHandler;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(characterTag)) return;
        
        InteractUI.Instance.Show(messageText);
        onTrigger = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(characterTag)) return;
        
        InteractUI.Instance.Hide();
        onTrigger = false;
    }

    #endregion
}
