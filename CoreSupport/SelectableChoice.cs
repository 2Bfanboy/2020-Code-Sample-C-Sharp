using System;
using UnityEngine;
using UnityEngine.UI;
using Shiba.Core.Engine;

namespace Shiba.Core.Support
{
    internal class SelectableChoice : MonoBehaviour
    {
        public Choice _choice { get; set; }
        public Text _choiceText => GetComponentInChildren<Text>();

        // events to notify anyone who cares a choice was selected
        public delegate void ChoiceSelected(Choice c);
        public ChoiceSelected OnChoiceSelected;
        private void Awake()
        {
            this.OnChoiceSelected += GameObject.FindObjectOfType<NovelMaster>().ChoiceSelectedHandler;
        }
        public void SelectMe()
        {
            OnChoiceSelected(this._choice);
            Debug.Log("<color=teal>(1/2)<b>" + this._choice.DisplayText + "</b> has been selected.</color>");
        }

        private void OnDestroy()
        {
            try
            {
                this.OnChoiceSelected -= GameObject.FindObjectOfType<NovelMaster>().ChoiceSelectedHandler;
            }
            catch
            {
                Debug.Log("<color=red>Caught some error while destroying choices.</color>");
            }

        }
    }
}
