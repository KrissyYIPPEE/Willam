using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private Slider audioSlider = null;

    [SerializeField] private Text audioTextUI = null;

    private void Start()
    {
        LoadValue();
    }

    public void VolumeSlider(float volume)
    {
        audioTextUI.text = volume.ToString("0.0");
    }

    public void SaveVolumeButton()
    {
        float audioValue = audioSlider.value;
        PlayerPrefs.SetFloat("AudioValue", audioValue);
        LoadValue();
    }

    void LoadValue()
    {
        float audioValue = PlayerPrefs.GetFloat("AudioValue");
        audioSlider.value = audioValue;
        AudioListener.volume = audioValue;
    }
}
