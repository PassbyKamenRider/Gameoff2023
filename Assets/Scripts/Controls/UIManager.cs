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
    }

    public void ToggleOptions()
    {
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }
}
