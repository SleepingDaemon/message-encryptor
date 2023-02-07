using UnityEngine;

namespace SleepingDaemon.EncryptSystem
{
    public class LanguagePrimer : MonoBehaviour
    {
        [SerializeField] private char letterUpper, letterLower;

        public void AddLetters()
        {
            EncryptManager.Instance.AddLetter(letterLower);
            EncryptManager.Instance.AddLetter(letterUpper);
            //for (int i = 0; i < EncryptManager.Instance.messages.Count; i++)
            //{
            //    Message message = EncryptManager.Instance.messages[i];
            //    message.DecryptMessage();
            //}
        }
    }
}
