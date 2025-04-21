using UnityEngine;

public class CalendarPanelController : MonoBehaviour
{
    public GameObject calendarPanel;

    public void ShowCalendar()
    {
        calendarPanel.SetActive(true);
    }

    public void HideCalendar()
    {
        calendarPanel.SetActive(false);
    }
}
