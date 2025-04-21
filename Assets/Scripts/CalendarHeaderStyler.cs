using UnityEngine;
using UnityEngine.UI;

public class CalendarHeaderStyler : MonoBehaviour
{
    public Image btnColorReference; // arrastra aquí el btnColor
    public Image targetImage;       // el Image del header

    void Start()
    {
        if (btnColorReference != null && targetImage != null)
        {
            targetImage.color = btnColorReference.color;
        }
    }
}