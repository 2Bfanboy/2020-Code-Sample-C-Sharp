using System;
using System.Linq;
using UnityEngine;
using Shiba.Core;

namespace Shiba.Core.Engine
{
    // singleton design, psudo event system
    internal sealed class AchievementEngine
    {
        private static readonly AchievementEngine instance = new AchievementEngine();
        static AchievementEngine() { }
        private AchievementEngine()
        {
            achievements = Resources.LoadAll<Achievement>("Achievements/");
            Debug.Log(achievements.Length);
            Debug.Log("<color=fushica>Started...</color>");
        }
        public static AchievementEngine Instance
        {
            get
            {
                return instance;
            }
        }

        private static Achievement[] achievements;

        // dialog
        public static void ProgressDialogClick()
        {
            Debug.Log("<color=aqua>Recording dialog click.</color>");
            IncreasePlayerPrefInt("dialogCount", 1);
            CheckCompletion("dialogCount", Achievement.ProgressionType.dialogCount);
        }

        // ad
        public static void ProgressAdView()
        {
            Debug.Log("<color=aqua>Recording ad view.</color>");
            IncreasePlayerPrefInt("adCount", 1);
        }

        // route
        // pref name is just the route name
        public static void ProgressRouteCompletion(string routeName)
        {
            Debug.Log("<color=aqua>Recording dialog click.</color>");
            IncreasePlayerPrefInt(routeName, 1);
        }

        // Game exit
        public static void ProgressRouteExit()
        {
            Debug.Log("<color=aqua>Recording early route exit.</color>");
            IncreasePlayerPrefInt("earlyExitCount", 1);
        }

        private static void IncreasePlayerPrefInt(string prefName, int increment)
        {
            var original = PlayerPrefs.GetInt(prefName);
            var newValue = original + increment;
            PlayerPrefs.SetInt(prefName, newValue);
        }

        private static void CheckCompletion(string against, Achievement.ProgressionType type)
        {
            // option 1) Check all achievements each time
            // option 2) Allocate more memory to check a sublist each time
            // 2 probably better in the long run as it grows
            if(achievements.Length == 0)
            {
                Debug.Log("<color=red>No achievements to be checked...</color>");
                return;
            }
            foreach(var x in achievements)
            {
                if(x.CompletionAmount == PlayerPrefs.GetInt(against) && x.AchievementProgressionType == type)
                {
                    // unlock the achievement
                    UnlockAchievement(x);
                }
            }
        }

        public static void UnlockAchievement(Achievement a)
        {
            Debug.Log("<color=lime><b>" + a.Title + "</b> has been unlocked.</color>");
            // send message to whoever cares
        }
    }
}
