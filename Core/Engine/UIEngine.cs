using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Shiba.Extensions;
using Shiba.Core.Support;
using DG.Tweening;

namespace Shiba.Core.Engine
{
    sealed internal class UIEngine : MonoBehaviour
    {
        [Header("Settings")]
        [Range(0f, 0.5f)]
        [SerializeField] private float typingSpeed = 0.05f;

        [Header("Main")]
        [SerializeField] private Text _speakerName = default;
        [SerializeField] private Text _dialogContent = default;
        [SerializeField] private Image _backgroundImage = default;

        [Header("Sub")]
        [SerializeField] private GameObject _choiceObject = default;
        [SerializeField] private GameObject _choicePanel = default;

        [Space]
        [SerializeField] private Animator _transitionAnimator = default;

        public delegate void TypingComplete(bool b);
        public event TypingComplete OnTypingCompleted;

        public bool IsTyping { get; private set; }

        public void UpdateVisuals(ref Dialog d)
        {
            StartCoroutine(TypeDialogContent(d.Payload));
        }

        public void SetSpeakerName(string s)
        {
            _speakerName.text = s;
        }

        public void PopulateAndDisplayChoices(ref Conversation c)
        {
            _choicePanel.SetActive(true);
            var x = 960f;
            var y = 1920f / (c.Choices.Length + 1);
            for (var i = 0; i < c.Choices.Length; i++)
            {
                var newPosition = x - (y * (i + 1));
                var go = (GameObject)Instantiate(_choiceObject);
                go.GetComponent<SelectableChoice>()._choiceText.text = c.Choices[i].DisplayText;
                go.transform.SetParent(_choicePanel.transform, false);
                go.transform.localPosition = new Vector3(0f, newPosition, 0f);
                go.GetComponent<SelectableChoice>()._choice = c.Choices[i];
            }
        }

        public void PopulateAndDisplayChoices(ref Dialog d)
        {
            _choicePanel.SetActive(true);
            var x = 960f;
            var y = 1920f / (d.FollowupChoices.Length + 1);
            for (var i = 0; i < d.FollowupChoices.Length; i++)
            {
                var newPosition = x - (y * (i + 1));
                var go = (GameObject)Instantiate(_choiceObject);
                go.GetComponent<SelectableChoice>()._choiceText.text = d.FollowupChoices[i].DisplayText;
                go.transform.SetParent(_choicePanel.transform, false);
                go.transform.localPosition = new Vector3(0f, newPosition, 0f);
                go.GetComponent<SelectableChoice>()._choice = d.FollowupChoices[i];
            }
        }

        public void ResetChoicePanel()
        {
            _choicePanel.transform.KillAllChildren();
            _choicePanel.SetActive(false);
        }


        public IEnumerator TypeDialogContent(string content)
        {
            if (IsTyping)
            {
                IsTyping = false;
                _dialogContent.text = content;
                OnTypingCompleted(true); // fire event
                StopAllCoroutines();
                yield return null;
            }
            _dialogContent.ClearMe();
            OnTypingCompleted(false);
            foreach (char letter in content.ToCharArray())
            {
                IsTyping = true;
                _dialogContent.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
            IsTyping = false;
            OnTypingCompleted(true);
        }

        public void ConversationTransition()
        {
            _transitionAnimator.SetBool("isLoaded", false);
            _transitionAnimator.Play("Expand");
        }

        public void ConversationLoadedHandler()
        {
            _transitionAnimator.SetBool("isLoaded", true);
        }

        public void SetBackgroundFromConversation(ref Conversation c)
        {
            try
            {
                _backgroundImage.sprite = Resources.Load<Sprite>("Backgrounds/" + c.Background.ToString());
            }
            catch
            {
                Debug.Log("<color=red>Couldn't locate background image <b>" + c.Background.ToString() + "</b></color>");
            }
        }
    }
}
