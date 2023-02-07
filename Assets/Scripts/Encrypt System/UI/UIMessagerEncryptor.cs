using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

namespace SleepingDaemon.EncryptSystem
{
    public class UIMessagerEncryptor : MonoBehaviour
    {
        public TMP_Text MessageText;
        public GameObject messageUIObject;

        public EncryptManager EncryptManager;

        private void Awake()
        {
            EncryptManager = FindObjectOfType<EncryptManager>();
        }

        public void ViewMessage(string message)
        {
            Debug.Log("Viewing Message");
            MessageText.text = message;
            OpenPanel();
        }

        private void Start()
        {
            if (EncryptManager != null)
            {
                Debug.Log("EncryptManage is not null");

                foreach (var msg in EncryptManager.messages)
                {
                    msg.OnMessageAdded += ViewMessage;
                }
            }

            ClosePanel();
        }

        private void OnDisable()
        {

        }

        private void OpenPanel()
        {
            messageUIObject.SetActive(true);
        }

        private void ClosePanel()
        {
            messageUIObject.SetActive(false);
        }
    }
}