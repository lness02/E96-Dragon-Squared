
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider soundSlider;

    private void Start(){
        SetSoundVolume();
    }

    public void SetSoundVolume()
    {
        float volume = soundSlider.value;
        myMixer.SetFloat("sound", Mathf.Log10(volume)*20);
    }
}
