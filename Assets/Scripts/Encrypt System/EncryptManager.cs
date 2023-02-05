using System;
using System.Collections.Generic;
using UnityEngine;

namespace SleepingDaemon.EncryptSystem
{
    public class EncryptManager : MonoBehaviour
    {
        public static EncryptManager Instance { get; private set; }
        public List<char> lettersFound = new List<char>();
        public List<Message> messages = new List<Message>();

        private void OnEnable()
        {
            foreach (var message in messages)
            {
                message.OnMessageDecrypt += HandleMessageOutput;
            }
        }

        private void OnDisable()
        {
            foreach(var message in messages)
            {
                message.OnMessageDecrypt -= HandleMessageOutput;
            }
        }

        private void HandleMessageOutput(string message)
        {
            Debug.Log(message);
        }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;
        }

        public void AddLetter(char letter)
        {
            if (lettersFound.Contains(letter)) return;

            lettersFound.Add(letter);
        }
    }
}
