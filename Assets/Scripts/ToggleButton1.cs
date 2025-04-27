using UnityEngine;
using UnityEngine.UI;

public class ToggleButton1 : MonoBehaviour
{
    public bool isOn = false;
    public Image background;
    public Color onColor = Color.white;
    public Color offColor = Color.black;

    public void Toggle()
    {
        isOn = !isOn;
        background.color = isOn ? onColor : offColor;
    }
}
