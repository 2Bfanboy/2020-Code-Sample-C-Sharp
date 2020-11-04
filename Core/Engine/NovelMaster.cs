using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Shiba.Extensions;

namespace Shiba.Core.Engine
{
    [RequireComponent(typeof(DialogEngine))]
    [RequireComponent(typeof(UIEngine))]
    sealed internal class NovelMaster : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private DialogEngine _DialogEngine = default;
        [SerializeField] private UIEngine _UIEngine = default;
        [SerializeField] private AudioEngine _AudioEngine = default;
        [SerializeField] private Keyring _SettingsKeyring = default;
        [SerializeField] private Conversation _conversation = default; // just for debugging

        private int storyIndex = 0;
        private Conversation nextConversation;
        private Dialog[] currentDialogs;

        public delegate void ConversationLoaded();
        public event ConversationLoaded OnConversationLoaded;

        private void OnTypingCompletedHandler(bool b)
        {
            canProceed = b;
        }

        private void Start()
        {
            SubscribeToEvents();
            _UIEngine.SetBackgroundFromConversation(ref _conversation);
            currentDialogs = _conversation.Dialogs;
            SpawnCharacterModels(ref _conversation);
            ProceedDialog(ref currentDialogs[0]);
            _AudioEngine.PlayBackgroundMusic(_conversation);
        }

        private bool canProceed;
        public void ProceedDialog(ref Dialog d)
        {
            _DialogEngine.DisplayDialogContent(ref d);
            _AudioEngine.PlayDialogVoice(ref d);
        }

        private void SpawnCharacterModels(ref Conversation c)
        {
            var toSpawn = new List<string>();
            foreach (var x in c.Dialogs)
            {
                if (!toSpawn.Contains(x.CurrentCharacter.ToString()))
                    toSpawn.Add(x.CurrentCharacter.ToString());
            }
            foreach (var x in toSpawn)
            {
                var y = Instantiate(Resources.Load<GameObject>("Models/" + x));
                y.name = x;
                y.HideMe();
            }
        }

        private void RemoveCharacterModelsFromScene()
        {
            foreach (var x in GameObject.FindGameObjectsWithTag("Character"))
            {
                x.transform.parent = null;
                x.name = "$disposed";
                Destroy(x);
                x.SetActive(false);
            }
        }

        public void ProceedButton()
        {
            if (canProceed)
            {
                storyIndex++;
                try
                {
                    ProceedDialog(ref currentDialogs[storyIndex]);
                }
                catch
                {
                    // it means there are choices that need to be addressed
                    if (currentDialogs[storyIndex - 1].FollowupChoices.Length != 0)
                    {
                        _UIEngine.PopulateAndDisplayChoices(ref currentDialogs[storyIndex - 1]);
                    }
                    else
                    {
                        _UIEngine.ConversationTransition();
                    }
                }
            }
            else
            {
                _UIEngine.UpdateVisuals(ref currentDialogs[storyIndex]);
            }
        }

        public void ChoiceSelectedHandler(Choice c)
        {
            // handle here
            Debug.Log("<color=teal>(2/2)<b>" + c.DisplayText + "</b> has been received.</color>");
            storyIndex = 0;
            nextConversation = Resources.Load<Conversation>(c.NextConversationPath); // candidate for change
            currentDialogs = c.FollowupDialogs;
            _UIEngine.ResetChoicePanel();
            ProceedDialog(ref currentDialogs[storyIndex]);
        }

        // StateMachineBehaviour notifies that it's safe to reset the scene
        public void ResetScene()
        {
            Debug.Log("Ready to reset...");
            RemoveCharacterModelsFromScene();
            _DialogEngine.ResetDialogEngine();
            storyIndex = 0;
            _conversation = nextConversation;
            nextConversation = null;
            currentDialogs = _conversation.Dialogs;
            SpawnCharacterModels(ref _conversation);
            _UIEngine.SetBackgroundFromConversation(ref _conversation);
            OnConversationLoaded(); // tell whoever cares
            ProceedDialog(ref currentDialogs[0]);
        }

        private void SubscribeToEvents()
        {
            _UIEngine.OnTypingCompleted += OnTypingCompletedHandler;
            OnConversationLoaded += _UIEngine.ConversationLoadedHandler;
        }

        private void UnsubscribeToEvents()
        {
            _UIEngine.OnTypingCompleted -= OnTypingCompletedHandler;
            OnConversationLoaded -= _UIEngine.ConversationLoadedHandler;
        }
        private void OnApplicationQuit()
        {
            _SettingsKeyring.AutoSave(_conversation, storyIndex);
            UnsubscribeToEvents();
        }
    }
}
