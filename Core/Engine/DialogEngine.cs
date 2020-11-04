using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shiba.Core;
using Shiba.Extensions;
using Shiba.Core.Support;

namespace Shiba.Core.Engine
{
    // handles every component associated with a dialog object
    sealed internal class DialogEngine : MonoBehaviour
    {
        // needs to manage dialog components:
        // Current Speaker, Expression, ContentPayload, Voice clip, Extras
        [Range(1f, 12f)]
        [SerializeField] private float modelSize = 12f;
        [SerializeField] private UIEngine _UIEngine = default;

        public void CheckExtras(ref Dialog d)
        {
            if (d.Red)
                Extras.TurnRedBriefly(ref currentCharacter);
            if (d.Green)
                Extras.TurnGreenBriefly(ref currentCharacter);
            if (d.ShakeMe)
                Extras.Shake(ref currentCharacter);
            if (d.ZoomIn)
                Extras.ZoomIn(ref currentCharacter);
        }

        // Core purpose:
        private GameObject currentCharacter = null;
        public void DisplayDialogContent(ref Dialog d)
        {
            AchievementEngine.ProgressDialogClick();
            SetCharacter(ref d);
            _UIEngine.UpdateVisuals(ref d);
            _UIEngine.SetSpeakerName(currentCharacter.GetComponent<CharacterName>().FirstName);
            Extras.CheckExtras(ref d, ref currentCharacter);
        }
        // utility
        private void SetCharacter(ref Dialog d)
        {
            if (currentCharacter == null)
            {
                currentCharacter = GameObject.Find(d.CurrentCharacter.ToString());
                currentCharacter.RestoreMe(modelSize);
                Debug.Log("<color=lime>" + currentCharacter.transform.localScale.x + "</color>");
                return;
            }
            if (currentCharacter.name != d.CurrentCharacter.ToString())
            {
                currentCharacter.HideMe();
                currentCharacter = GameObject.Find(d.CurrentCharacter.ToString());
                currentCharacter.RestoreMe(modelSize);
            }
        }

        public void ResetDialogEngine()
        {
            // add things here as they come
            currentCharacter = null;
        }
    }
}
