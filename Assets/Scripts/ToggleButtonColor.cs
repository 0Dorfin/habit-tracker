using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CopyColorFromImage : MonoBehaviour
{
    public Image sourceImage;    // btnColor
    public Image targetImage;    // Imagen del botón (btnGood)
    public TMP_Text buttonText;  // Texto del botón (opcional)

    public void CopyColor()
    {
        if (sourceImage != null && targetImage != null)
        {
            targetImage.color = sourceImage.color;
        }

        if (buttonText != null)
        {
            buttonText.color = Color.white;
        }
    }
}
