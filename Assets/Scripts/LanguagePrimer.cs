using UnityEngine;

namespace SleepingDaemon.EncryptSystem
{
    public class LanguagePrimer : MonoBehaviour
    {
        [SerializeField] private char letterUpper, letterLower;
        private EncryptManager encryptor;

        private void Awake()
        {
            encryptor = FindObjectOfType<EncryptManager>();
        }

        public void AddLetters()
        {
            encryptor.AddLetter(letterLower);
            encryptor.AddLetter(letterUpper);
            for (int i = 0; i < encryptor.messages.Count; i++)
            {
                Message message = encryptor.messages[i];
                message.DecryptMessage();
            }
        }
    }
}
