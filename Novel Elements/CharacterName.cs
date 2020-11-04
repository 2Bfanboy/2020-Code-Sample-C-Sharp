using UnityEngine;

namespace Shiba.Core
{
    public class CharacterName : MonoBehaviour
    {
        [Header("English Core")]
        [SerializeField] private string firstNameEN = "";

        [Header("Japanese Core")]
        [SerializeField] private string firstNameJP = "";

        public string FirstName
        {
            get
            {
                switch (PlayerPrefs.GetString("textLang"))
                {
                    case "en":
                        return firstNameEN;
                    case "jp":
                        return firstNameJP;
                    default:
                        Debug.Log("<color=red>WARNING: LANG SETTING NOT SET.</color>");
                        return firstNameJP;
                }
            }
        }
    }
}

