using UnityEngine;

public class ButtonAddHandler : MonoBehaviour
{
    public GameObject createHabitPanel;

    public void ShowCreateHabitPanel()
    {
        Debug.Log("Click detectado");
        if (createHabitPanel != null)
        {
            createHabitPanel.SetActive(true);
        }
    }

}
