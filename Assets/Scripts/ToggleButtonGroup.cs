using UnityEngine;
using System.Collections.Generic;

public class ToggleButtonGroup : MonoBehaviour
{
    public List<ToggleButton> buttons;
    public ToggleButton selectedButton;

    public ToggleButton SelectedButton => selectedButton;

    public void OnButtonSelected(ToggleButton selected)
    {
        foreach (var btn in buttons)
        {
            if (btn != selected)
                btn.Deselect();
        }

        selectedButton = selected;
    }

    public void UpdateSelectedColor(Color newColor)
    {
        if (selectedButton != null)
        {
            selectedButton.UpdateColor(newColor);
        }
    }
}
