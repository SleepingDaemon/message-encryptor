using UnityEngine;

namespace SleepingDaemon.EncryptorSystem
{
    public class LanguagePrimer : MonoBehaviour
    {
        [SerializeField] private char letterUpper, letterLower;
        private MessageEncryptor encryptor;

        private void Awake()
        {
            encryptor = FindObjectOfType<MessageEncryptor>();
        }

        public void AddLetters()
        {
            encryptor.AddLetter(letterLower);
            encryptor.AddLetter(letterUpper);
            encryptor.DecryptMessage();
        }
    }
}
