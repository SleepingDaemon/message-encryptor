using TMPro;
using UnityEngine;

namespace SleepingDaemon.EncryptSystem
{
    public class UIMessagerEncryptor : MonoBehaviour
    {
        public TMP_Text MessageText;
        public EncryptManager messageEncryptor;

        private void OnEnable()
        {
            //messageEncryptor.OnMessageDecrypt += HandleMessageDecryption;
        }

        private void OnDisable()
        {
            //messageEncryptor.OnMessageDecrypt -= HandleMessageDecryption;
        }

        private void HandleMessageDecryption(string message)
        {
            MessageText.text = message;
        }
    }
}