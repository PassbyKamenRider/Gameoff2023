using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string header;
    public string description;
    public void OnPointerEnter(PointerEventData eventData)
    {
        ToolTipSystem.Show(header, description);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipSystem.Hide();
    }
}
