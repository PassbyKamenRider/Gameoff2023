using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Button btn;
    public Dropdown dropdown;
    public Slider slider;
    public Text text;
    public AudioSource audio_source;

    public const float hundred = 100f; 
    private void Awake()
    {
        btn.onClick.AddListener(DropDownChange);
    }

    private void Update()
    {
        slider.value = audio_source.volume;
        slider.onValueChanged.AddListener((float value) => AudioChange(value));
        var volume_value = hundred * slider.value;
        text.text = volume_value.ToString("f0") + "%";
    }

    public void DropDownChange()
    {
        switch (dropdown.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, true);  // full screen
                break;
            case 1:
                Screen.SetResolution(1440, 900, false);  // window
                break;
            case 2:
                Screen.SetResolution(1280, 720, false);  // window
                break;
            default:
                break;
        }
        return;
    }
    public void AudioChange(float value)
    {
        audio_source.volume = value;
    }
}
