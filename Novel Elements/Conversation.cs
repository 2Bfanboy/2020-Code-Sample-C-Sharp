using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shiba.Core
{
    [CreateAssetMenu(fileName = "conversation00", menuName = "Shiba/Create conversation")]
    sealed internal partial class Conversation : ScriptableObject
    {
        [Header("Descriptions")]
        [SerializeField] private string titleEN = default;
        [SerializeField] private string descriptionEN = default;
        [SerializeField] private string titleJP = default;
        [SerializeField] private string descriptionJP = default;

        [Header("Core")]
        [SerializeField] private Dialog[] dialogs = default;
        [SerializeField] private Choice[] choices = default;
        [SerializeField] private Backgrounds background = default;
        [SerializeField] private BGMs bgm = default;

        /// <summary> (read only) All dialogs, in order of appearance, for this conversation</summary>
        public Dialog[] Dialogs => dialogs;
        /// <summary> (read only) Initial background image displayed in scene</summary>
        public Backgrounds Background => background;
        /// <summary> (read only) Initial background music playing in the scene</summary>
        public BGMs Bgm => bgm;
        /// <summary>(read only) (English) Choices to be displayed when dialog exhausted</summary>
        public Choice[] Choices => choices;

        public string Title
        {
            get
            {
                switch (PlayerPrefs.GetString("textLang"))
                {
                    case "en":
                        return titleEN;
                    case "jp":
                        return titleJP;
                    default:
                        Debug.Log("<color=red>WARNING: LANG SETTING NOT SET.</color>");
                        return titleEN;
                }
            }
        }

        public string Description
        {
            get
            {
                switch (PlayerPrefs.GetString("textLang"))
                {
                    case "en":
                        return descriptionEN;
                    case "jp":
                        return descriptionJP;
                    default:
                        Debug.Log("<color=red>WARNING: LANG SETTING NOT SET.</color>");
                        return descriptionEN;
                }
            }
        }

        public List<Character> FindConversationCharacters()
        {
            var result = new List<string>();
            foreach (var x in this.Dialogs)
            {
                if (!result.Contains(x.CurrentCharacter.ToString()))
                {
                    result.Add(x.CurrentCharacter.ToString());
                }
            }
            var finalResult = new List<Character>();
            foreach (var x in result)
            {
                Debug.Log("<color=lime><b>" + x + " </b> will be included in this conversation.</color>");
                finalResult.Add(Resources.Load<Character>("Characters/" + x));
            }
            return finalResult;
        }

    }
}
