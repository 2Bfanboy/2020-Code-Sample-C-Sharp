using UnityEngine;

namespace Shiba.Core.Support
{
    [CreateAssetMenu(fileName = "portraitSet00", menuName = "Shiba/Create portrait set")]
    sealed internal class PortraitSet : ScriptableObject
    {
        [Header("Utility")]
        [SerializeField] private string lookupCode = "";

        // English
        [Header("English Core")]
        [SerializeField] private string setNameEN = "";
        [SerializeField] private string setDescriptionEN = "";

        // Japanese
        [Header("Japanese Core")]
        [SerializeField] private string setNameJP = "";
        [SerializeField] private string setDescriptionJP = "";

        // Shared
        [Header("Portraits")]
        [SerializeField] private Sprite neutral = default;
        [SerializeField] private Sprite happy = default;
        [SerializeField] private Sprite sad = default;
        [SerializeField] private Sprite surprised = default;
        [SerializeField] private Sprite embarassed = default;

        // English
        /// <summary>(read only) (English) set's title name</summary>
        public string SetNameEN => setNameEN;
        /// <summary>(read only) (English) set's detailed description</summary>
        public string SetDescriptionEN => setDescriptionEN;

        // Japanese
        /// <summary>(read only) (Japanese) set's title name</summary>
        public string SetNameJP => setNameJP;
        /// <summary>(read only) (Japanese) set's detailed description</summary>
        public string SetDescriptionJP => setDescriptionJP;

        // Shared
        /// <summary>(read only) ID for finding this asset in code</summary>
        public string LookupCode => lookupCode;
        public Sprite Neutral => neutral;
        public Sprite Happy => happy;
        public Sprite Sad => sad;
        public Sprite Surprised => surprised;
        public Sprite Embarassed => embarassed;
    }
}
