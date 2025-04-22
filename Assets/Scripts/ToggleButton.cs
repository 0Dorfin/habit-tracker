using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToggleButton : MonoBehaviour
{
    public ToggleButtonGroup group;
    public Image background;
    public TMP_Text text;
    public Image btnColorReference;

    private bool isSelected = false;

    public void OnClick()
    {
        if (group != null)
            group.OnButtonSelected(this); // Dile al grupo que este ha sido seleccionado

        isSelected = true;

        if (btnColorReference != null)
            background.color = btnColorReference.color;

        if (text != null)
            text.color = Color.white;
    }

    public void Deselect()
    {
        isSelected = false;
        background.color = Color.white;
        text.color = Color.black;
    }

    // Nuevo método para actualizar el color desde el grupo
    public void UpdateColor(Color newColor)
    {
        if (isSelected)
        {
            background.color = newColor;
            if (text != null)
                text.color = Color.white;
        }
    }
}
