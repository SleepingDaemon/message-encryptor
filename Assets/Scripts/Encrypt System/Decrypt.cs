using SleepingDaemon.EncryptSystem;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(Encrypt))]
public class Decrypt : MonoBehaviour
{
    [SerializeField] private string[] decryptedValues;
    private string[] originalValues;
    private Encrypt _encrypt;

    private void Awake()
    {
        _encrypt = GetComponent<Encrypt>();
    }

    private void Start()
    {
        if(_encrypt != null)
        {
            originalValues = _encrypt.SetOrignalValues();
            EncryptManager.Instance.OnLetterAdded += UpdateDecryptedMessage;
        }
        else
        {
            Debug.Log("No Encrypt Component found!");
        }
    }

    private void UpdateDecryptedMessage()
    {
        string[] encryptedValues = _encrypt.SetEncryptedValues();
        decryptedValues= new string[encryptedValues.Length];

        for (int i = 0; i < encryptedValues.Length; i++)
        {
            decryptedValues[i] = DecryptMessage(encryptedValues[i]);
        }
    }

    public string DecryptMessage(string encryptedValue)
    {
        char[] decryptedString = encryptedValue.ToCharArray();

        for (int i = 0; i < decryptedString.Length; i++)
        {
            if (!decryptedString[i].Equals(' ') &&
                !decryptedString[i].Equals(',') &&
                !decryptedString[i].Equals('.') &&
                !decryptedString[i].Equals('!') &&
                !decryptedString[i].Equals(':'))
            {
                if (EncryptManager.Instance.lettersFound.Contains((char)(decryptedString[i] - 3)))
                {
                    decryptedString[i] = (char)(decryptedString[i] - 3);
                }
            }
        }

        return new string(decryptedString);
    }
}
