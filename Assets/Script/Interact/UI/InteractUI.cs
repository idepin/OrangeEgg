using TMPro;
using UnityEngine;

public class InteractUI : SingletonPrefab<InteractUI>
{
    #region Fields

    [SerializeField] private TextMeshProUGUI txtMessage;

    #endregion

    #region Methods

    public void Show(string message)
    {
        txtMessage.SetText(message);
        gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    #endregion
}
