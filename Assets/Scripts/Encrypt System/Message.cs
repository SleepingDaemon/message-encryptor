using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SleepingDaemon.EncryptSystem
{
    public class Message : MonoBehaviour
    {
        [SerializeField] private string author;
        [SerializeField] private int date;
        [SerializeField] private string title;
        [TextArea(2, 10)]
        [SerializeField] string message = null;
        [SerializeField] private bool encrypt = false;

        // Public Properties
        public string Author => author;
        public int Date => date;
        public string Title => title;
        public string OriginalMessage => message;

        private void Start()
        {
            if (encrypt)
            {
                Encrypt encrypt = gameObject.AddComponent<Encrypt>();
                Decrypt decrypt = gameObject.AddComponent<Decrypt>();
            }
        }

        public string SetMessage() => message;


        public void InitMessage()
        {
            EncryptManager.Instance.AddMessage(this);
        }

        public bool CanEncrypt() => encrypt;
    }
}
