using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections;

public class ScrollWheelTimesPopulator : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    [Header("Referencias")]
    public RectTransform contentParent;
    public TMP_Text textTemplate;
    public RectTransform viewport;
    public ScrollRect scrollRect;
    private int paddingTop = 80;


    [Header("Configuración")]
    public int maxValue = 100;
    public float itemHeight = 40f;

    private bool isDragging = false;
    private float totalContentHeight => (maxValue + 1) * itemHeight;
    private float centerOffset => totalContentHeight / 2f;

    void Start()
    {
        PopulateScroll();
        SnapToInitial();
    }

    void PopulateScroll()
    {
        for (int i = 1; i <= maxValue; i++)
        {
            TMP_Text newItem = Instantiate(textTemplate, contentParent);
            newItem.text = i.ToString("D2");
            newItem.gameObject.SetActive(true);
        }

        textTemplate.gameObject.SetActive(false);
    }

    void SnapToInitial()
    {
        contentParent.anchoredPosition = new Vector2(0, -centerOffset + itemHeight * 0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        StopAllCoroutines();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        StartCoroutine(SnapToNearest());
    }

    IEnumerator SnapToNearest()
    {
        yield return new WaitForEndOfFrame();

        float currentY = contentParent.anchoredPosition.y;
        int nearestIndex = Mathf.RoundToInt(currentY / itemHeight);

        nearestIndex = Mathf.Clamp(nearestIndex, 0, maxValue);

        float targetY = nearestIndex * itemHeight;
        float duration = 0.15f;
        float t = 0f;

        Vector2 startPos = contentParent.anchoredPosition;
        Vector2 targetPos = new Vector2(startPos.x, targetY);

        while (t < 1)
        {
            t += Time.deltaTime / duration;
            contentParent.anchoredPosition = Vector2.Lerp(startPos, targetPos, t);
            yield return null;
        }

        contentParent.anchoredPosition = targetPos;
    }



    public string GetSelectedValue()
    {
        float yOffset = contentParent.anchoredPosition.y;
        int index = Mathf.RoundToInt(yOffset / itemHeight);
        index = Mathf.Clamp(index, 0, maxValue - 1);
        return (index + 1).ToString("D2");
    }


}
