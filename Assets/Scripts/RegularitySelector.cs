using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RegularitySelector : MonoBehaviour
{
    [Header("Botones de regularidad")]
    public Button everydayBtn;
    public Button onceWeekBtn;
    public Button threeWeekBtn;
    public Button fiveWeekBtn;
    public Button customBtn;

    [Header("Panel personalizado")]
    public GameObject customPanel;

    [Header("Texto a actualizar")]
    public TMP_Text summaryFrequencyText;

    [Header("Botón guardar")]
    public Button saveButton;

    [Header("Panel de selección de regularidad")]
    public GameObject regularityPanel;

    [Header("Scroll personalizado")]
    public ScrollWheelTimesPopulator timesSelector;
    public ScrollWheelTextPopulator regularitySelector;
    [Header("Botones de abrir/cancelar")]
    public Button openPanelButton;
    public Button cancelButton;


    private string selectedFrequency = "";

    void Start()
    {
        // Asignar listeners
        everydayBtn.onClick.AddListener(() => SelectFrequency("Cada día", false));
        onceWeekBtn.onClick.AddListener(() => SelectFrequency("Una vez a la semana", false));
        threeWeekBtn.onClick.AddListener(() => SelectFrequency("3 veces a la semana", false));
        fiveWeekBtn.onClick.AddListener(() => SelectFrequency("5 veces a la semana", false));
        customBtn.onClick.AddListener(() => SelectFrequency("Personalizado", true));

        saveButton.onClick.AddListener(SaveSelection);

        openPanelButton.onClick.AddListener(OpenRegularityPanel);
    cancelButton.onClick.AddListener(CloseRegularityPanel);
    }

    void SelectFrequency(string frequencyText, bool showCustom)
    {
        selectedFrequency = frequencyText;
        customPanel.SetActive(showCustom);
    }

    void SaveSelection()
    {
        string result = "";

        if (selectedFrequency == "Personalizado")
        {
            string times = timesSelector.GetSelectedValue();         
            string frequencyRaw = regularitySelector.GetSelectedText(); 
            string frequency = char.ToLower(frequencyRaw[0]) + frequencyRaw.Substring(1);

            if (times == "01")
                result = $"una vez {frequency}";
            else
                result = $"{int.Parse(times)} veces {frequency}";
        }
        else
        {
            result = $"{selectedFrequency}";
        }

        summaryFrequencyText.text = result;

        if (regularityPanel != null)
        {
            regularityPanel.SetActive(false);
        }
    }

    void OpenRegularityPanel()
    {
        if (regularityPanel != null)
            regularityPanel.SetActive(true);
    }

    void CloseRegularityPanel()
    {
        if (regularityPanel != null)
            regularityPanel.SetActive(false);
    }


}
