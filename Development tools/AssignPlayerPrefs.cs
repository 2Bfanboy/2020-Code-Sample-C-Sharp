using UnityEngine;

namespace Shiba.Dev
{
    public class AssignPlayerPrefs : MonoBehaviour
    {
        [SerializeField]
        private Language textLanguage;
        [SerializeField]
        private Language voiceLanguage;
        public enum Language
        {
            
            en,
            jp
        }

        void Awake()
        {
            PlayerPrefs.SetString("textLang", textLanguage.ToString());
            PlayerPrefs.SetString("voiceLang", voiceLanguage.ToString());
        }
    }
}
