using UnityEngine;
using TMPro;

public class TimePicker : MonoBehaviour
{
    public TMP_Dropdown hourDropdown;
    public TMP_Dropdown minuteDropdown;

    void Start()
    {
        // Llenar horas
        hourDropdown.ClearOptions();
        for (int i = 0; i < 24; i++)
            hourDropdown.options.Add(new TMP_Dropdown.OptionData(i.ToString("D2")));

        // Llenar minutos
        minuteDropdown.ClearOptions();
        for (int i = 0; i < 60; i++)
            minuteDropdown.options.Add(new TMP_Dropdown.OptionData(i.ToString("D2")));

        hourDropdown.RefreshShownValue();
        minuteDropdown.RefreshShownValue();
    }

    public string GetSelectedTime()
    {
        string hour = hourDropdown.options[hourDropdown.value].text;
        string minute = minuteDropdown.options[minuteDropdown.value].text;
        return $"{hour}:{minute}";
    }
}
