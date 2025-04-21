using UnityEngine;
using UnityEngine.UI;

public class ColorPickerManager : MonoBehaviour
{
    [Header("Colores que se mostrarán en los botones")]
    public Color[] colorOptions;

    [Header("Botones circulares (uno por color)")]
    public GameObject[] colorButtons;

    [Header("Imagen que cambia al seleccionar un color")]
    public Image targetColorImage;

    void Start()
    {
        for (int i = 0; i < colorButtons.Length && i < colorOptions.Length; i++)
        {
            var button = colorButtons[i];

            if (button == null)
            {
                Debug.LogWarning($"[ColorPickerManager] El botón en la posición {i} es null.");
                continue;
            }

            var img = button.GetComponent<Image>();
            var cb = button.GetComponent<ColorButton>();

            if (img != null)
                img.color = colorOptions[i];

            if (cb != null)
            {
                cb.colorToSelect = colorOptions[i];
                cb.targetImage = targetColorImage;
            }
            else
            {
                Debug.LogWarning($"[ColorPickerManager] El botón '{button.name}' no tiene el componente ColorButton.");
            }
        }
    }
}
