using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HabitCard : MonoBehaviour
{
    [Header("Referencias UI")]
    public Image habitImg;
    public TMP_Text habitNameTxt;
    public TMP_Text numberTimesTxt; 
    public TMP_Text timesDayTxt;
    public Image icon; 

    public void Setup(Habit habit)
    {
        habitNameTxt.text = habit.name;
        timesDayTxt.text = habit.frequency;
        numberTimesTxt.text = $"{habit.completed}/{habit.totalRequired}";

        if (habit.totalRequired > 9)
        {
            RectTransform rt = numberTimesTxt.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x - 10, rt.anchoredPosition.y);
        }

        habitImg.color = habit.color;
    }
}
