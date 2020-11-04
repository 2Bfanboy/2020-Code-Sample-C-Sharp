using UnityEngine;

namespace Shiba.Core
{
    sealed internal partial class Achievement
    {
        public enum ProgressionType
        {
            dialogCount,
            adCount,
            earlyExitCount,
            routeCompletion,
            setRoutesCompleted,
            totalRoutesCompleted,
            playthroughJP,
            playthroughEN,
            weeklyShiba,
            settings,
            outfits
        };

        public enum Tier
        {
            bronze,
            silver,
            gold
        };
    }
}
