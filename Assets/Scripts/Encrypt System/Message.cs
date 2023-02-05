using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SleepingDaemon.EncryptSystem
{
    public class Message : MonoBehaviour
    {
        public event Action<string> OnMessageDecrypt;

        [SerializeField] private string author;
        [SerializeField] private string date;
        [SerializeField] private string title;
        [TextArea(2, 10)][SerializeField] string messageToEncrypt = null;   // the message to encrypt
        [TextArea(2, 10)][SerializeField] string encryptedMSG = null;       // the encrypted message

        // Public Properties
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
            if (messageToEncrypt != null)
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
                        if (EncryptManager.Instance.lettersFound.Contains(messageToEncrypt[i]))
                        {
                            decryptedMessage[i] = messageToEncrypt[i];
                        }
                    }
                }
            }

            OnMessageDecrypt?.Invoke(decryptedMessage.ToString());

            return decryptedMessage.ToString();
        }
    }
}
