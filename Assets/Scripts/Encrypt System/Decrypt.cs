using SleepingDaemon.EncryptSystem;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(Encrypt))]
public class Decrypt : MonoBehaviour
{
    [SerializeField] private string decryptedMSG;
    private string originalMSG;
    private Encrypt _encrypt;

    private void Awake()
    {
        _encrypt = GetComponent<Encrypt>();
    }

    private void Start()
    {
        if(_encrypt != null)
            originalMSG = _encrypt.GetOriginalMessage();

        EncryptManager.Instance.OnLetterAdded += UpdateDecryptedMessage;
    }

    private void UpdateDecryptedMessage()
    {
        decryptedMSG = DecryptMessage();
    }

    public string DecryptMessage()
    {
        string encryptedMSG = _encrypt.GetEncryptedMessage();

        StringBuilder decryptedMessage = new StringBuilder(encryptedMSG);

        for (int i = 0; i < encryptedMSG.Length; i++)
        {
            for (int x = 0; x < originalMSG.Length; x++)
            {
                if (encryptedMSG[i] != originalMSG[x])
                {
                    if (EncryptManager.Instance.lettersFound.Contains(originalMSG[i]))
                    {
                        decryptedMessage[i] = originalMSG[i];
                    }
                }
            }
        }

        return decryptedMessage.ToString();
    }
}
