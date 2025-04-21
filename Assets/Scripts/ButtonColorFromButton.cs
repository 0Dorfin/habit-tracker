using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonTextColorFromBtnColor : MonoBehaviour
{
    [Header("Referencias")]
    public Image btnColor;         // El botón de donde tomas el color
    public Button targetButton;    // El botón que contiene el texto a cambiar

    void Start()
    {
        ApplyColor();
    }

    public void ApplyColor()
    {
        if (btnColor != null && targetButton != null)
        {
            TMP_Text text = targetButton.GetComponentInChildren<TMP_Text>();
            if (text != null)
            {
                text.color = btnColor.color;
            }
        }
    }
}
