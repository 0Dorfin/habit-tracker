using UnityEngine;
using TMPro;

public class ReminderTimeManager : MonoBehaviour
{
    [Header("Panel de selector de hora")]
    public GameObject reminderPanel;

    [Header("Textos UI")]
    public TMP_Text reminderHour;       // Ej: "Hora: 05:07"
    public TMP_Text reminderText;       // Cambia de "Crear recordatorio" a "Editar"

    [Header("Scroll de hora/minuto")]
    public ScrollWheelPopulator hourPicker;
    public ScrollWheelPopulator minutePicker;

    private bool reminderSet = false;

    public void OnSaveTime()
    {
        int hour = hourPicker.GetSelectedValue();
        int minute = minutePicker.GetSelectedValue();


        string formattedTime = $"{hour:00}:{minute:00}";

        if (reminderHour != null)
        {
            reminderHour.text = $"Hora: {formattedTime}";
            reminderHour.gameObject.SetActive(true); // ← mostrar cuando se guarda
        }

        if (reminderText != null)
            reminderText.text = "Editar";

        reminderSet = true;

        if (reminderPanel != null)
            reminderPanel.SetActive(false);
    }

    public void OnCancel()
    {
        if (!reminderSet && reminderText != null)
            reminderText.text = "Crear recordatorio";

        if (reminderPanel != null)
            reminderPanel.SetActive(false);
    }
}
