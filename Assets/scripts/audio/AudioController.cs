using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace game.package.audio
{
    public class AudioController : MonoBehaviour
    {
        public string mixerParamName;
        public AudioSource audioSource;
        public AudioMixer audioMixer;
        public RectTransform soundToggleButton; 
        public Sprite soundOnSprite;
        public Sprite soundMuteSprite;

        private bool isSoundEffectOn;

        private void Start()
        {
            isSoundEffectOn = true;
        }

        public void SetLevel(float value)
        {
            audioMixer.SetFloat(mixerParamName, Mathf.Log10(value) * 20);
        }

        public void ToggleSound()
        {
            bool found = audioMixer.GetFloat(mixerParamName, out float volume);
            bool isSoundOn = !((found && volume > 0.0001f) || audioSource.isPlaying);
            if(isSoundOn)
            {
                audioSource.Play();
                soundToggleButton.GetComponent<Image>().sprite = soundOnSprite;
            }
            else
            {
                audioSource.Pause();
                soundToggleButton.GetComponent<Image>().sprite = soundMuteSprite;
            }
        }

        public void SetSoundFXLevel(float value)
        {
            SetLevel(value);
            if (!audioSource.isPlaying)
                audioSource.Play();
        }

        public void ToggleSoundFX()
        {
            isSoundEffectOn = !isSoundEffectOn;
            SetSoundFXLevel(isSoundEffectOn ? 1f : 0.001f);
            soundToggleButton.GetComponent<Image>().sprite = isSoundEffectOn ? soundOnSprite : soundMuteSprite;
        }
    }
}