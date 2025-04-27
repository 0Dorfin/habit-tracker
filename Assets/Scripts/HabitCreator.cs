using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class HabitCreator : MonoBehaviour
{
    [Header("Referencias UI")]
    public TMP_InputField nameInput;

    [Header("Color RGB")]
    public Slider sliderR;
    public Slider sliderG;
    public Slider sliderB;

    [Header("Color botón")]
    public Image btnColorImage;

    [Header("Frecuencia")]
    public TMP_Text frequencySummaryText;

    [Header("Grupos de botones")]
    public ToggleButtonGroup habitTypeGroup;
    public ToggleButtonGroup startDateGroup;
    public ToggleButtonGroup timeOfDayGroup;

    [Header("Recordatorio")]
    public TMP_Text reminderHourText;

    [Header("Paneles de Pantallas")]
    public GameObject routineView;
    public GameObject createHabitView;

    [Header("Referencias extra")]
    public DatesHome datesHome;

    public void SaveHabit()
    {
        if (string.IsNullOrEmpty(nameInput.text))
        {
            Debug.LogWarning("❗ El nombre del hábito está vacío");
            return;
        }

        Habit habit = new Habit();

        habit.name = nameInput.text;
        habit.color = GetSelectedColor();
        habit.type = GetSelectedButtonLabel(habitTypeGroup);
        habit.startDate = GetSelectedButtonLabel(startDateGroup);
        habit.frequency = frequencySummaryText.text;
        habit.timeOfDay = GetSelectedButtonLabel(timeOfDayGroup);
        habit.reminderTime = ExtractTimeFromText(reminderHourText.text);
        habit.totalRequired = ExtractNumberFromFrequency(frequencySummaryText.text);
        habit.completed = 0;

        HabitSystemManager.Instance.AddHabit(habit);

        Debug.Log($"✅ Hábito guardado correctamente: {habit.name}");

        datesHome.CountHabits();

        createHabitView.SetActive(false);
        routineView.SetActive(true);
    }

    private Color GetSelectedColor()
    {
        Color selectedColor = new Color(sliderR.value, sliderG.value, sliderB.value);

        if (selectedColor.r == 0 && selectedColor.g == 0 && selectedColor.b == 0)
        {
            selectedColor = new Color(146f / 255f, 0f, 1f);
        }

        return selectedColor;
    }

    public void UpdateButtonColor()
    {
        Color selectedColor = new Color(sliderR.value, sliderG.value, sliderB.value);
        btnColorImage.color = selectedColor;
    }

    private string GetSelectedButtonLabel(ToggleButtonGroup group)
    {
        if (group != null && group.selectedButton != null)
        {
            TMP_Text label = group.selectedButton.GetComponentInChildren<TMP_Text>();
            if (label != null)
            {
                return label.text;
            }
            return group.selectedButton.name;
        }
        return "Unknown";
    }

    private int ExtractNumberFromFrequency(string frequencyText)
    {
        Match match = Regex.Match(frequencyText, @"\d+");
        if (match.Success)
        {
            return int.Parse(match.Value);
        }
        return 1;
    }

    private string ExtractTimeFromText(string fullText)
    {
        return fullText.Replace("Hora: ", "").Trim();
    }
}
