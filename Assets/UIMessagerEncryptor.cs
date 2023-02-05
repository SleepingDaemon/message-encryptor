using System;
using TMPro;
using UnityEngine;

public class UIMessagerEncryptor : MonoBehaviour
{
    public TMP_Text MessageText;
    public MessageEncryptor messageEncryptor;

    private void OnEnable()
    {
        messageEncryptor.OnMessageDecrypt += HandleMessageDecryption;
    }

    private void OnDisable()
    {
        messageEncryptor.OnMessageDecrypt -= HandleMessageDecryption;
    }

    private void HandleMessageDecryption(string message)
    {
        MessageText.text = message;
    }
}
