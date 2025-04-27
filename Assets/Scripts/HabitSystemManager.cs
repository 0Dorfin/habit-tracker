using System.Collections.Generic;
using UnityEngine;

public class HabitSystemManager : MonoBehaviour
{
    public static HabitSystemManager Instance;

    public List<Habit> habitList = new List<Habit>();
    public delegate void HabitAdded(Habit habit);
    public event HabitAdded OnHabitAdded;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddHabit(Habit habit)
    {
        habitList.Add(habit);
        Debug.Log("Hábito añadido: " + habit.name);

        OnHabitAdded?.Invoke(habit);
    }
}
