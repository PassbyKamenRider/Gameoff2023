using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private RawImage[] volumeDisplays;
    [SerializeField] private RawImage resolutionDisplay;
    [SerializeField] Texture2D emptyVolume;
    [SerializeField] Texture2D fullVolume;
    [SerializeField] Texture2D[] resolutions;
    private int resolution = 0;

    public void ChangeVolume(int num)
    {
        AudioListener.volume = 0.1f * num;
        for (int i = 0; i < volumeDisplays.Length; i++)
        {
            if (i < num)
            {
                volumeDisplays[i].texture = fullVolume;
            }
            else
            {
                volumeDisplays[i].texture = emptyVolume;
            }
        }
    }

    public void ChangeResolution()
    {
        resolution = 1 - resolution;
        resolutionDisplay.texture = resolutions[resolution];

        switch(resolution)
        {
            case 0:
                Screen.SetResolution(1280, 720, true);
                break;
            
            case 1:
                Screen.SetResolution(1920, 1080, true);
                break;

            default:
                break;
        }
    }

    public void ToggleOptions()
    {
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }
}
