using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class MessageEncryptor : MonoBehaviour
{
    // the message to encrypt
    [TextArea(2, 8)]
    [SerializeField] private string messageToEncrypt = null;

    // the encrypted message
    [SerializeField] public string encryptedMSG = null;

    [SerializeField] private List<char> lettersFound = new List<char>();

    public event Action<string> OnMessageDecrypt;

    private string newEncryptedMessage;

    public string MessageToEncrypt
    {
        get
        {
            return messageToEncrypt;
        }
        set
        {
            messageToEncrypt = value;
        }
    }
    public string EncryptedMessage
    {
        get
        {
            return encryptedMSG;
        }
        set
        {
            encryptedMSG = value;
        }
    }

    private void Start()
    {
        if(messageToEncrypt != null)
        {
            encryptedMSG = Encrypt(messageToEncrypt);
        }
        else
            Debug.Log("No message input to encrypt. Add a message!");

        Debug.Log(encryptedMSG);
    }

    public string Encrypt(string message)
    {
        // Encrypt the message
        char[] encryptMSG = message.ToCharArray();
        for (int i = 0; i < encryptMSG.Length; i++)
        {
            // if the letter contains: ' ', !, ., then do not encrypt.
            if (!encryptMSG[i].Equals(' ') && !encryptMSG[i].Equals(',') && !encryptMSG[i].Equals('.')
                && !encryptMSG[i].Equals('!'))
            {
                encryptMSG[i] = (char)(encryptMSG[i] + Random.Range(3, 4) % 26);
            }
        }

        return new string(encryptMSG);
    }

    public string DecryptMessage()
    {
        StringBuilder decryptedMessage = new StringBuilder(encryptedMSG);

        for (int i = 0; i < encryptedMSG.Length; i++)
        {
            for (int x = 0; x < messageToEncrypt.Length; x++)
            {
                if (encryptedMSG[i] != messageToEncrypt[x])
                {
                    if (lettersFound.Contains(messageToEncrypt[i]))
                    {
                        //newEncryptedMessage = encryptedMSG.Replace(encryptedMSG[i], messageToEncrypt[x]);
                        decryptedMessage[i] = messageToEncrypt[i];
                        OnMessageDecrypt?.Invoke(decryptedMessage.ToString());
                    }
                }
            }
        }

        return decryptedMessage.ToString();
    }


    public void AddLetter(char letter)
    {
        if (lettersFound.Contains(letter)) return;

        lettersFound.Add(letter);
    }
}
