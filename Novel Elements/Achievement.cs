using UnityEngine;

namespace Shiba.Core
{
    [CreateAssetMenu(fileName = "achievement000", menuName = "Shiba/Create achievement")]
    sealed internal partial class Achievement : ScriptableObject
    {
        [Header("English")]
        [SerializeField] private string titleEN = "";
        [SerializeField] private string descriptionEN = "";

        [Header("Japanese")]
        [SerializeField] private string titleJP = "";
        [SerializeField] private string descriptionJP = "";

        [Header("Shared")]
        [SerializeField] private Sprite icon = default;
        [SerializeField] private Tier tier = default; 
        [SerializeField] private ProgressionType progressionType = default;
        [SerializeField] private int completionAmount = 0;

        [Header("If using routeCompletion")]
        [SerializeField] private string routeName = default;
        [SerializeField] private string[] routeNames = default;

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
        
        public int CompletionAmount => completionAmount;
        public ProgressionType AchievementProgressionType => progressionType;
        public Tier AchievementTier => tier;
        public Sprite Icon => icon;
        public string RouteName => routeName;
        public string[] RouteNames => routeNames;
    
    }
}
