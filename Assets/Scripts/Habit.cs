using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Habit
{
    public string name;
    public string type;
    public string frequency;
    public string timeOfDay;
    public string startDate;
    public List<DayOfWeek> days;
    public int totalRequired;
    public int completed;
    public Color color;
    public string reminderTime;
}
