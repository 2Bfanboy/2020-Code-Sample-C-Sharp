using UnityEngine;

namespace Shiba.Core
{
    [CreateAssetMenu(fileName = "dialog000", menuName = "Shiba/Create dialog")]
    sealed internal partial class Dialog : ScriptableObject
    {
        // Shared
        [Header("Speaker")]
        [SerializeField] private DialogCharacters currentCharacter = default;
        [SerializeField] private Expressions expression = default;

        // English
        [Header("English Core")]
        [TextArea(2, 8)]
        [SerializeField] private string payloadEN = "";
        [SerializeField] private AudioClip voiceEN = default;

        // Japanese
        [Header("Japanese Core")]
        [TextArea(2, 8)]
        [SerializeField] private string payloadJP = "";
        [SerializeField] private AudioClip voiceJP = default;

        [Space]
        [Header("Movement")]
        [SerializeField] private bool shakeMe = false;
        [SerializeField] private bool littleJump = false;
        [Header("Effects")]
        [SerializeField] private bool zoomIn = false;
        [Header("Colors")]
        [SerializeField] private bool longDarken = false;
        [SerializeField] private bool red = false;
        [SerializeField] private bool green = false;

        [Header("Resetting")]
        [SerializeField] private bool restoreColor = false;
        [SerializeField] private bool restoreSize = false;
        // add a narrator thing here maybe

        [Header("Choice chaining")]
        [SerializeField] private Choice[] followupChoices = default;



        // Shared
        /// <summary>(read only) The character associated with this dialog</summary>
        public DialogCharacters CurrentCharacter => currentCharacter;
        /// <summary>(read only) The expression used to lookup the portrait to use</summary>
        public Expressions Expression => expression;
        /// <summary>(read only) The resulting payload based on localization setting</summary>
        public string Payload
        {
            get
            {
                switch (PlayerPrefs.GetString("textLang"))
                {
                    case "en":
                        return payloadEN;
                    case "jp":
                        return payloadJP;
                    default:
                        Debug.Log("<color=red>WARNING: LANG SETTING NOT SET.</color>");
                        return payloadEN;
                }
            }
        }

        /// <summary>(read only) The resulting voice clip based on localization setting</summary>
        public AudioClip Voice
        {
            get
            {
                switch (PlayerPrefs.GetString("voiceLang"))
                {
                    case "en":
                        return voiceEN;
                    case "jp":
                        return voiceJP;
                    default:
                        Debug.Log("<color=red>WARNING: VOICE LANG SETTING NOT SET.</color>");
                        return voiceEN;
                }
            }
        }

        // English 
        /// <summary>(read only) (English) word content of this dialog</summary>
        public string PayloadEN => payloadEN;
        /// <summary>(read only) (English) Voice acting of this dialog</summary>
        public AudioClip VoiceEN => voiceEN;

        // Japanese
        /// <summary>(read only) (Japanese) word content of this dialog</summary>
        public string PayloadJP => payloadJP;
        /// <summary>(read only) (Japanese) Voice acting of this dialog</summary>
        public AudioClip VoiceJP => voiceJP;

        // new
        public bool ShakeMe => shakeMe;
        public bool LittleJump => littleJump;
        public bool LongDarken => longDarken;
        public bool Red => red;
        public bool Green => green;
        public bool ZoomIn => zoomIn;
        public bool RestoreColor => restoreColor;
        public bool RestoreSize => restoreSize;

        public Choice[] FollowupChoices => followupChoices;
    }
}
