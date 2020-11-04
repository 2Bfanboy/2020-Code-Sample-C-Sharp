using System;
using UnityEngine;

namespace Shiba.Extensions
{
    public static class CustomExtensions
    {
        public static void HideMe(this GameObject go)
        {
            go.transform.localScale = new Vector3(0f, 0f, 0f);
        }

        public static void RestoreMe(this GameObject go, float x)
        {
            go.transform.localScale = new Vector3(x, x, x);
        }

        public static void ClearMe(this UnityEngine.UI.Text t)
        {
            t.text = "";
        }

        public static void KillAllChildren(this Transform transform)
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}