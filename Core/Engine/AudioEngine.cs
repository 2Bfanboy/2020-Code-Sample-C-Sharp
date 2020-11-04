using UnityEngine;
using Shiba.Core;

namespace Shiba.Core.Engine
{
    sealed internal class AudioEngine : MonoBehaviour
    {
        [SerializeField] private AudioSource _backgroundAudioSource = default;
        [SerializeField] private AudioSource _voiceAudioSource = default;

        public void PlayDialogVoice(ref Dialog d)
        {
            _voiceAudioSource.PlayOneShot(d.Voice);
        }

        public void PlayBackgroundMusic(Conversation c)
        {
            _backgroundAudioSource.clip = Resources.Load<AudioClip>("Music/" + c.Bgm.ToString());
            _backgroundAudioSource.Play();
        }
    }
}
