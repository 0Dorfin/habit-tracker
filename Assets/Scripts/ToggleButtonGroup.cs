using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ToggleButtonGroup : MonoBehaviour
{
    public List<ToggleButton> buttons;

    public void OnButtonSelected(ToggleButton selected)
    {
        foreach (var btn in buttons)
        {
            if (btn != selected)
                btn.Deselect();
        }
    }
}
