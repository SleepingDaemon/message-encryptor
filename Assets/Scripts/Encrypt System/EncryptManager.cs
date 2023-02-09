using System;
using System.Collections.Generic;
using UnityEngine;

namespace SleepingDaemon.EncryptSystem
{
    public class EncryptManager : MonoBehaviour
    {
        public event Action OnLetterAdded;
        public event Action OnMessageAdded;

        public static EncryptManager Instance { get; private set; }
        public List<char> lettersFound = new List<char>();
        public List<Message> messages = new List<Message>();

        private UIMessagerEncryptor viewMessage;

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;

            viewMessage = FindObjectOfType<UIMessagerEncryptor>();
        }

        public void AddLetter(char letter)
        {
            if (lettersFound.Contains(letter)) return;

            lettersFound.Add(letter);
            OnLetterAdded?.Invoke();
        }

        public void AddMessage(Message message)
        {
            messages.Add(message);
            OnMessageAdded?.Invoke();
        }
    }
}
