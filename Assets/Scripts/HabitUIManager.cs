using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HabitUIManager : MonoBehaviour
{
    [Header("Prefabs y Secciones")]
    public GameObject habitCardPrefab;
    public Transform morningSection;
    public Transform afternoonSection;
    public Transform eveningSection;
    public Transform anyTimeSection;

    [Header("Textos de Contador de Secciones")]
    public TMP_Text morningTitle;
    public TMP_Text afternoonTitle;
    public TMP_Text eveningTitle;
    public TMP_Text anyTimeTitle;

    [Header("Content Principal")]
    public RectTransform contentRoot; // 🔥 Añadimos esto para poder forzar el layout

    private void Start()
    {
        HabitSystemManager.Instance.OnHabitAdded += OnHabitCreated;
        DisplayHabits();
    }

    void DisplayHabits()
    {
        foreach (Habit habit in HabitSystemManager.Instance.habitList)
        {
            CreateHabitCard(habit);
        }
        UpdateSectionVisibility();
    }

    void OnHabitCreated(Habit habit)
    {
        CreateHabitCard(habit);
        UpdateSectionVisibility();
    }

    void CreateHabitCard(Habit habit)
    {
        GameObject card = Instantiate(habitCardPrefab, GetSection(habit.timeOfDay), false);

        card.transform.localPosition = new Vector3(0, -50, 0);  // 🔥 Un pequeño offset hacia abajo
        card.transform.localScale = Vector3.one;

        HabitCard habitCard = card.GetComponent<HabitCard>();
        habitCard.Setup(habit);
    }

    Transform GetSection(string timeOfDay)
    {
        timeOfDay = timeOfDay.ToLower().Trim();

        if (timeOfDay.Equals("mañana")) return morningSection;
        if (timeOfDay.Equals("tarde")) return afternoonSection;
        if (timeOfDay.Equals("noche")) return eveningSection;
        if (timeOfDay.Equals("cualquiera") || timeOfDay.Equals("cualquier hora")) return anyTimeSection;

        Debug.LogWarning($"No se reconocio el TimeOfDay '{timeOfDay}', enviado a AnyTimeSection por defecto.");
        return anyTimeSection;
    }

    void UpdateSectionVisibility()
    {
        UpdateSection(morningSection, morningTitle);
        UpdateSection(afternoonSection, afternoonTitle);
        UpdateSection(eveningSection, eveningTitle);
        UpdateSection(anyTimeSection, anyTimeTitle);

        // 🔥 Después de actualizar todo, forzamos el layout
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentRoot);
    }

    void UpdateSection(Transform section, TMP_Text title)
    {
        int habitCards = 0;
        foreach (Transform child in section)
        {
            if (child.CompareTag("HabitCard"))
            {
                habitCards++;
            }
        }

        section.gameObject.SetActive(habitCards > 0);

        string baseTitle = title.text.Split('(')[0].Trim();
        title.text = $"{baseTitle} ({habitCards})";

        LayoutElement layout = section.GetComponent<LayoutElement>();
        if (layout != null)
        {
            layout.ignoreLayout = (habitCards == 0);
        }
    }
}
