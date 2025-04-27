using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Globalization;

public class DatesHome : MonoBehaviour
{
    [Header("Prefabs y Contenedores")]
    public GameObject dateItemPrefab;
    public Transform contentParent;

    [Header("UI de la fecha de hoy")]
    public TextMeshProUGUI todayDateText;

    [Header("UI de hábitos restantes")]
    public TextMeshProUGUI habitsLeftText;
    public int totalHabits = 0;
    public int completedHabits = 0;

    private void Start()
    {
        GenerateWeek();
        UpdateTodayDate();
        UpdateHabitsLeft();
    }

    void GenerateWeek()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        DateTime today = DateTime.Now.Date;

        for (int i = -3; i <= 3; i++)
        {
            DateTime currentDay = today.AddDays(i);
            string rawDay = currentDay.ToString("ddd", new CultureInfo("es-ES"));
            string cleanDay = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(rawDay.TrimEnd('.'));
            string dayNumber = currentDay.Day.ToString();

            GameObject dateObj = Instantiate(dateItemPrefab, contentParent);

            TextMeshProUGUI dayText = dateObj.transform.Find("DateWeektxt")?.GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI numberText = dateObj.transform.Find("Numbertxt")?.GetComponent<TextMeshProUGUI>();
            Image bgImage = dateObj.transform.Find("DateImg")?.GetComponent<Image>();

            if (dayText != null) dayText.text = cleanDay;
            if (numberText != null) numberText.text = dayNumber;

            if (currentDay == today && bgImage != null)
            {
                bgImage.color = Color.white;
                if (dayText != null) dayText.color = Color.black;
                if (numberText != null) numberText.color = Color.black;
            }
        }
    }

    void UpdateTodayDate()
    {
        if (todayDateText == null) return;

        DateTime today = DateTime.Now;
        
        string dayName = today.ToString("dddd", new CultureInfo("es-ES"));
        string monthName = today.ToString("MMMM", new CultureInfo("es-ES"));

        dayName = char.ToUpper(dayName[0]) + dayName.Substring(1);
        monthName = char.ToUpper(monthName[0]) + monthName.Substring(1);

        string formattedDate = $"{dayName}, {today:dd} {monthName}";

        todayDateText.text = formattedDate;
    }


    public void UpdateHabitsLeft()
    {
        if (habitsLeftText == null) return;

        int remainingHabits = totalHabits - completedHabits;

        if (remainingHabits == 1)
        {
            habitsLeftText.text = "1 Hábito pendiente";
        }
        else if (remainingHabits == 0)
        {
            habitsLeftText.text = "¡Sin hábitos pendientes!";
        }
        else
        {
            habitsLeftText.text = $"{remainingHabits} Hábitos pendientes";
        }
    }



    public void CountHabits()
    {
        int count = 0;

        HabitCard[] allHabitCards = FindObjectsOfType<HabitCard>();

        foreach (var habit in allHabitCards)
        {
            if (habit.gameObject.activeInHierarchy)
            {
                count++;
            }
        }

        totalHabits = count;
        UpdateHabitsLeft();
    }
}
