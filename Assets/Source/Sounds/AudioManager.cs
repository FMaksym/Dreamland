using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _musicSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("SoundVolume") && PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetSoundVolume();
            SetMusicVolume();
        }
    }

    public void SetSoundVolume()
    {
        float volume = _soundSlider.value;
        _mixer.SetFloat("Sound", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SoundVolume", volume);
    }

    public void SetMusicVolume()
    {
        float volume = _musicSlider.value;
        _mixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void LoadVolume()
    {
        _soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1.0f);
        _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1.0f);

        SetSoundVolume();
        SetMusicVolume();
    }
}
