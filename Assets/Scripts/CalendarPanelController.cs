using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UI.Dates;

public class CalendarPanelController : MonoBehaviour
{
    public DatePicker datePicker;
    public TMP_Text anotherText;
    public GameObject calendarPanel;

    public void ShowCalendar()
    {
        calendarPanel.SetActive(true);
    }

    public void HideCalendar()
    {
        calendarPanel.SetActive(false);
    }

    public void OnCancel()
    {
        if (calendarPanel != null)
            calendarPanel.SetActive(false);
    }

    public void OnSaveDate()
    {
        System.DateTime selectedDate = datePicker.SelectedDate;

        if (selectedDate == default)
            return;

        string formatted = selectedDate.ToString("M/d/yy");

        if (anotherText != null)
            anotherText.text = formatted;

        if (calendarPanel != null)
            calendarPanel.SetActive(false);
    }

}
