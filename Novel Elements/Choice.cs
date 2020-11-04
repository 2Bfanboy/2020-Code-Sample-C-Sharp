using UnityEngine;

namespace Shiba.Core
{
    [CreateAssetMenu(fileName = "choice00", menuName = "Shiba/Create choice")]
    sealed internal class Choice : ScriptableObject
    {
        [Header("Shared Core")]
        [SerializeField] private Dialog[] followupDialogs = default;
        [SerializeField] private string nextConversationPath = "Conversations/";

        [Header("Display")]
        [SerializeField] private string displayTextEN = "";
        [SerializeField] private string displayTextJP = "";

        // Shared
        /// <summary>(read only) The dialogs that proceed the selected choice</summary>
        public Dialog[] FollowupDialogs => followupDialogs;
        /// <summary>(read only) The dialogs that proceed the selected choice</summary>
        public string NextConversationPath => nextConversationPath;

        // Display text content
        /// <summary>(read only) (English) The textual representation of this choice, displayed</summary>
        public string DisplayTextEN => displayTextEN;
        /// <summary>(read only) (Japanese) The textual representation of this choice, displayed</summary>
        public string DisplayTextJP => displayTextJP;

        public string DisplayText
        {
            get
            {
                switch (PlayerPrefs.GetString("textLang"))
                {
                    case "en":
                        return displayTextEN;
                    case "jp":
                        return displayTextJP;
                    default:
                        Debug.Log("<color=red>WARNING: CHOICE LANG SETTING NOT SET.</color>");
                        return displayTextJP;
                }
            }
        }
    }
}
