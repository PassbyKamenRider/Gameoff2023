using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipSystem : MonoBehaviour
{
    private static ToolTipSystem instance;
    public ToolTip toolTip;
    private void Awake() {
        instance = this;
    }
    public static void Show(string header, string description)
    {
        instance.toolTip.SetText(header, description);
        instance.toolTip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        instance.toolTip.gameObject.SetActive(false);
    }
}
