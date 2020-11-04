using UnityEngine;


namespace Shiba.Core
{
    // save settings and options ? 
    sealed internal class Keyring : MonoBehaviour
    {
        [SerializeField] private bool useAutoSave = false;
        // works
        // maybe have a different saving system for regular save ?  figure it out later
        public void AutoSave(Conversation c, int i)
        {
            if (useAutoSave)
            {
                PlayerPrefs.SetString("conversation", c.name);
                PlayerPrefs.SetInt("conversationIndex", i);
                Debug.Log("<color=lime>Saving conversation <color=aqua><b>" + c.name+ "</b></color> at index <color=aqua><b>" + i + "</b></color></color>");
            }
            else
            {
                Debug.Log("<color=red>Auto save is turned off. Game data wasn't saved.</color>");
            }
        }

        // rest of settings will be configurable through this later
    }
}
