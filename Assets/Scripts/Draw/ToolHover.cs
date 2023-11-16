using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToolHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Texture2D defaultTexture;
    [SerializeField] private Texture2D hoverTexture;
    [SerializeField] public int toolType;
    [SerializeField] private RawImage[] rawImages;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (DrawManager.chosenTool != toolType)
        {
            SwitchHover();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (DrawManager.chosenTool != toolType)
        {
            SwitchDefault();
        }
    }

    public void SwitchHover()
    {
        foreach (RawImage img in rawImages)
        {
            img.texture = hoverTexture;
        }
    }

    public void SwitchDefault()
    {
        foreach (RawImage img in rawImages)
        {
            img.texture = defaultTexture;
        }
    }
}
