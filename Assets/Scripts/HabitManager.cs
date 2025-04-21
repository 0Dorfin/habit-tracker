using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HabitManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_InputField inputName;
    public Image colorPreview;
    public Button[] buttonsToColor;

    private Habit currentHabit = new Habit();

    void Start()
    {
        // Color inicial por defecto (puedes cambiarlo si querés)
        SetColor(Color.white);
    }

    public void SetColor(Color color)
    {
        currentHabit.habitColor = color;
        colorPreview.color = color;
        ApplyColorToButtons();
    }

    public void SaveHabit()
    {
        currentHabit.habitName = inputName.text;
        Debug.Log("Hábito guardado:");
        Debug.Log("Nombre: " + currentHabit.habitName);
        Debug.Log("Color: " + ColorUtility.ToHtmlStringRGB(currentHabit.habitColor));
        
        // Aquí podrías guardar en una lista, archivo, etc.
    }

    private void ApplyColorToButtons()
    {
        foreach (var btn in buttonsToColor)
        {
            ColorBlock cb = btn.colors;
            cb.normalColor = currentHabit.habitColor;
            cb.highlightedColor = currentHabit.habitColor;
            cb.pressedColor = currentHabit.habitColor;
            cb.selectedColor = currentHabit.habitColor;
            btn.colors = cb;
        }
    }
}
