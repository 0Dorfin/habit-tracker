using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class OptionSelector : MonoBehaviour
{
    [System.Serializable]
    public class Option
    {
        public Button button;
        public GameObject tick;
        public TMP_Text label;
    }

    public List<Option> options;
    private int selectedIndex = -1;

    void Start()
    {
        for (int i = 0; i < options.Count; i++)
        {
            int index = i;
            options[i].button.onClick.AddListener(() => OnOptionSelected(index));
        }
    }

    void OnOptionSelected(int index)
    {
        for (int i = 0; i < options.Count; i++)
        {
            options[i].tick.SetActive(i == index);
        }

        selectedIndex = index;
        Debug.Log("Opción seleccionada: " + options[index].label.text);
    }

    public string GetSelectedText()
    {
        if (selectedIndex >= 0)
            return options[selectedIndex].label.text;
        return null;
    }

    public int GetSelectedIndex()
    {
        return selectedIndex;
    }
}
