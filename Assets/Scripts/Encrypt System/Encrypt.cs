using SleepingDaemon.EncryptSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Message))]
public class Encrypt : MonoBehaviour
{
    [SerializeField] private string[] encryptedValues;
    [TextArea(1, 10)][SerializeField] private string[] originalValues = new string[3];
    [SerializeField] private List<char> charsToIgnore = new List<char>();

    private string originalMSG, originalAUTH, originalTITLE;
    private Message message;

    private void Awake()
    {
        message = GetComponent<Message>();
    }

    private void Start()
    {
        if(message != null && message.CanEncrypt())
        {
            originalAUTH = message.Author;
            originalTITLE = message.Title;
            originalMSG = message.OriginalMessage;

            originalValues[0] = originalAUTH;
            originalValues[1] = originalTITLE;
            originalValues[2] = originalMSG;

            if (originalValues.Length > 0)
            {
                encryptedValues = new string[originalValues.Length];
                for (int i = 0; i < originalValues.Length; i++)
                {
                    encryptedValues[i] = EncryptMessage(originalValues[i]);
                }
            }
        }
        else
            Debug.Log("No message input to encrypt. Add a message!");
    }

    public string EncryptMessage(string value)
    {
        string tempString = value;

        // Encrypt the message by character
        char[] encryptString = tempString.ToCharArray();
        for (int i = 0; i < encryptString.Length; i++)
        {
            // if the letter contains: ' ', !, ., then do not encrypt.
            if (!encryptString[i].Equals(' ') &&
                !encryptString[i].Equals(',') &&
                !encryptString[i].Equals('.') &&
                !encryptString[i].Equals('!') &&
                !encryptString[i].Equals(':'))
            {
                encryptString[i] = (char)(encryptString[i] + 3 % 26);
            }
        }

        return new string(encryptString);
    }

    public string[] SetEncryptedValues() => encryptedValues;
    public string[] SetOrignalValues() => originalValues;
}
