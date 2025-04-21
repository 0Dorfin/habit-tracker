using UnityEngine;

public class ToggleColorPicker : MonoBehaviour
{
    public GameObject colorPanel;

    public void TogglePanel()
{
    Debug.Log("Se hizo clic en el botón de color");
    if (colorPanel != null)
    {
        colorPanel.SetActive(!colorPanel.activeSelf);
    }
}

}
