using UnityEngine;

public class SelectedButtonColorUpdater : MonoBehaviour
{
    public UnityEngine.UI.Image btnColor; // El botón con el color elegido
    public ToggleButtonGroup group;

    private Color lastColor;

    void Start()
    {
        if (btnColor != null)
            lastColor = btnColor.color;
    }

    void Update()
    {
        if (btnColor != null && group != null)
        {
            if (btnColor.color != lastColor)
            {
                lastColor = btnColor.color;
                group.UpdateSelectedColor(lastColor);
            }
        }
    }
}
