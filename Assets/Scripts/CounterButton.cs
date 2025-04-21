using UnityEngine;
using TMPro;

public class CounterButton : MonoBehaviour
{
    public TMP_Text counterText;
    public int currentValue = 1;
    public int minValue = 1;
    public int maxValue = 99;

    public void Increase()
    {
        if (currentValue < maxValue)
        {
            currentValue++;
            UpdateDisplay();
        }
    }

    public void Decrease()
    {
        if (currentValue > minValue)
        {
            currentValue--;
            UpdateDisplay();
        }
    }

    void UpdateDisplay()
    {
        if (counterText != null)
            counterText.text = currentValue.ToString();
    }

    private void Start()
    {
        UpdateDisplay(); // Mostrar el valor inicial al arrancar
    }
}
