using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ColorPickerController : MonoBehaviour
{
    [Header("Sliders RGB")]
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;

    [Header("Preview / UI")]
    public Image preview;
    public TMP_Text saveButtonText;

    [Header("Botones")]
    public Button confirmButton;
    public Button cancelButton;
    public GameObject colorSliderPanel;

    [Header("Botón para abrir el panel")]
    public Button btnColorOpen; // <<--- Este es el nuevo botón

    [Header("Color actual (btnColor)")]
    public Image btnColor;

    [Header("Otros elementos opcionales")]
    public List<Graphic> colorLinkedElements;
    [Header("Grupos de botones que deben actualizarse")]
    public List<ToggleButtonGroup> toggleButtonGroups;



    private Color currentColor;

    void Start()
    {
        // Inicializar sliders y preview
        UpdateColor();

        redSlider.onValueChanged.AddListener(_ => UpdateColor());
        greenSlider.onValueChanged.AddListener(_ => UpdateColor());
        blueSlider.onValueChanged.AddListener(_ => UpdateColor());

        confirmButton.onClick.AddListener(ConfirmColor);
        cancelButton.onClick.AddListener(() => colorSliderPanel.SetActive(false));

        // Asignar evento al botón para abrir el panel
        btnColorOpen.onClick.AddListener(() => colorSliderPanel.SetActive(true));
    }

    void UpdateColor()
    {
        currentColor = new Color(
            redSlider.value / 255f,
            greenSlider.value / 255f,
            blueSlider.value / 255f
        );

        if (preview != null)
            preview.color = currentColor;

        if (saveButtonText != null)
            saveButtonText.color = currentColor;
    }

   void ConfirmColor()
    {
        if (btnColor != null)
            btnColor.color = currentColor;

        foreach (var element in colorLinkedElements)
        {
            if (element != null)
            {
                Color originalColor = element.color;
                Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, originalColor.a);
                element.color = newColor;
            }
        }

        // 🔁 Actualiza el botón seleccionado en cada grupo
        foreach (var group in toggleButtonGroups)
        {
            if (group != null)
                group.UpdateSelectedColor(currentColor);
        }

        colorSliderPanel.SetActive(false);
    }



    public Color GetSelectedColor()
    {
        return currentColor;
    }
}
