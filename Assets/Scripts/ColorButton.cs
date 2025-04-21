using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    public Image targetImage;      // Imagen que debe cambiar de color (btnColor)
    public Color colorToSelect;    // Color que este botón representa
    public GameObject colorPanel;  // Opcional: panel para ocultar después de seleccionar

    public void OnColorSelected()
    {
        if (targetImage != null)
        {
            targetImage.color = colorToSelect;
        }

        if (colorPanel != null)
        {
            colorPanel.SetActive(false);
        }
    }
}
