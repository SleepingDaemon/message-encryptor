using SleepingDaemon.EncryptSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Message))]
public class Encrypt : MonoBehaviour
{
    [TextArea(2, 10)] [SerializeField] string encryptedMSG = null;       // the encrypted message
    private string originalMSG;
    private Message message;

    public string EncryptedMessage => encryptedMSG;

    private void Awake()
    {
        message = GetComponent<Message>();
    }

    private void Start()
    {
        if(message != null && message.CanEncrypt())
            encryptedMSG = EncryptMessage();
        else
            Debug.Log("No message input to encrypt. Add a message!");
    }

    public string EncryptMessage()
    {
        // Get message string from Message component
        originalMSG = message.GetMessage();
        string tempMSG = originalMSG;

        // Encrypt the message by character
        char[] encryptMSG = tempMSG.ToCharArray();
        for (int i = 0; i < encryptMSG.Length; i++)
        {
            // if the letter contains: ' ', !, ., then do not encrypt.
            if (!encryptMSG[i].Equals(' ') &&
                !encryptMSG[i].Equals(',') &&
                !encryptMSG[i].Equals('.') &&
                !encryptMSG[i].Equals('!') &&
                !encryptMSG[i].Equals(':'))
            {
                encryptMSG[i] = (char)(encryptMSG[i] + Random.Range(3, 4) % 26);
            }
        }

        return new string(encryptMSG);
    }

    public string GetEncryptedMessage() => encryptedMSG;

    public string GetOriginalMessage() => originalMSG;
}
