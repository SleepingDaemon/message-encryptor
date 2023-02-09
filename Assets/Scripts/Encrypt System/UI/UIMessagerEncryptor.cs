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

        public void ViewMessage()
        {
            Debug.Log("Viewing Message");
            //MessageText.text = message;
            OpenPanel();
        }

        private void Start()
        {
            if (EncryptManager != null)
            {
                
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