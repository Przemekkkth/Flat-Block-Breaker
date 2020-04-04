using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [Header("Config params")]
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] int defaultDifficulty = 1;

    private void Start()
    {
       volumeSlider.value = PlayerPrefsController.GetMasterVolume();
       difficultySlider.value = PlayerPrefsController.GetMasterVolume();
    }

    private void Update()
    {
        SetMusicPlayer();
    }

    private void SetMusicPlayer()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found... did you start from splash screen");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        int intDifficultyValue = (int)difficultySlider.value;
        PlayerPrefsController.SetDifficulty( intDifficultyValue );
        FindObjectOfType<SceneLoader>().LoadMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
