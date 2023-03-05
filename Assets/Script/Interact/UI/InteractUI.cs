using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractUI : SingletonPrefab<InteractUI>
{
    [SerializeField] private TextMeshProUGUI txtMessage;
    private void Start()
    {
        //gameObject.SetActive(false);
    }

    public void Show(string message)
    {
        txtMessage.SetText(message);
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
