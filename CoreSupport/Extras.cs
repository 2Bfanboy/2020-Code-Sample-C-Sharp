using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Live2D.Cubism.Rendering;

namespace Shiba.Core.Support
{
    internal static class Extras
    {
        static float animationDuration = 1f;
        static Color32 darkenedShade = new Color32(121, 121, 121, 255);
        static Color32 defaultShade = new Color32(255, 255, 255, 255);
        static Color32 redShade = new Color32(219, 40, 40, 255);
        static Color32 greenShade = new Color32(63, 241, 71, 255);
        static Vector3 inactive = new Vector3(0f, 0f, 0f);

        public static void CheckExtras(ref Dialog d, ref GameObject me)
        {
            if (d.Red)
                TurnRedBriefly(ref me);
            if (d.Green)
                TurnGreenBriefly(ref me);
            if(d.LongDarken)
                TurnDark(ref me);
            if(d.RestoreColor)
                ReturnOriginalColor(ref me);
            if (d.ShakeMe)
                Shake(ref me);
            if (d.ZoomIn)
                ZoomIn(ref me);
        }


        public static void TurnRedBriefly(ref GameObject me)
        {
            foreach (var x in me.GetComponentsInChildren<CubismRenderer>())
            {
                x.Color = redShade;
            }
        }

        public static void TurnGreenBriefly(ref GameObject me)
        {
            foreach (var x in me.GetComponentsInChildren<CubismRenderer>())
            {
                x.Color = greenShade;
            }
        }

        public static void TurnDark(ref GameObject me)
        {
            foreach (var x in me.GetComponentsInChildren<CubismRenderer>())
            {
                x.Color = darkenedShade;
            }
        }

        public static void ReturnOriginalColor(ref GameObject me)
        {
            foreach (var x in me.GetComponentsInChildren<CubismRenderer>())
            {
                x.Color = defaultShade;
            }
        }

        public static void Shake(ref GameObject me)
        {
            me.transform.DOShakePosition(animationDuration);
        }

        public static void ZoomIn(ref GameObject me)
        {
            me.transform.DOScale(new Vector3(15f, 15f, 15f), animationDuration);
        }
    }
}
