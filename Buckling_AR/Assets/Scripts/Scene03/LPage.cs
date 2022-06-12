using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LPage : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    private ScrollRect scrollRect;
    private float[] PageArray = new float[] { 0f, 1f };
    private float targetHorizontalPosition = 0;
    public float smoothing = 5;
    private bool isDraging = false;
    private bool isNext = false;
    private bool isLast = false;

    static public int Parameter1 = 1;
    static public int Parameter2 = 1;

    static public int PageNumber1;
    static public int PageNumber2;

    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        PageNumber1 = 1;
        PageNumber2 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDraging == false || isNext == true || isLast == true)
        {
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, targetHorizontalPosition, Time.deltaTime * smoothing);
        }
        isNext = false;
        isLast = false;

        if (CreateScenePage.PageNumber == CheckTurnPageButton_CreateScene.PageOfCreateColumn1)
        {
            Parameter1 = PageNumber1;
        }
        if (CreateScenePage.PageNumber == CheckTurnPageButton_CreateScene.PageOfCreateColumn2)
        {
            Parameter2 = PageNumber2;

        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDraging = true;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        isDraging = false;
        float PosX = scrollRect.horizontalNormalizedPosition;
        int index = 0;
        float offset = Mathf.Abs(PageArray[index] - PosX);
        for (int i = 1; i < PageArray.Length; i++)
        {
            float offsetTemp = Mathf.Abs(PageArray[i] - PosX);
            if (offsetTemp < offset)
            {
                index = i;
                offset = offsetTemp;
            }
        }
        targetHorizontalPosition = PageArray[index];
        if (CreateScenePage.PageNumber == CheckTurnPageButton_CreateScene.PageOfCreateColumn1)
        {
            PageNumber1 = index + 1;
        }
        if (CreateScenePage.PageNumber == CheckTurnPageButton_CreateScene.PageOfCreateColumn2)
        {
            PageNumber2 = index + 1;
        }
    }
    public void NextPage()
    {
        isNext = true;
        float PosX = scrollRect.horizontalNormalizedPosition;
        int index = 1;

        for (int i = 0; i < PageArray.Length; i++)
        {
            if (Mathf.Abs(PosX - PageArray[i]) < 0.05)
            {
                index = i + 1;
            }
        }
        targetHorizontalPosition = PageArray[index];
        if (CreateScenePage.PageNumber == CheckTurnPageButton_CreateScene.PageOfCreateColumn1)
        {
            PageNumber1 = index + 1;
        }
        if (CreateScenePage.PageNumber == CheckTurnPageButton_CreateScene.PageOfCreateColumn2)
        {
            PageNumber2 = index + 1;
        }

    }
    public void LastPage()
    {
        isLast = true;
        float PosX = scrollRect.horizontalNormalizedPosition;
        int index = 1;

        for (int i = 0; i < PageArray.Length; i++)
        {
            if (Mathf.Abs(PosX - PageArray[i]) < 0.05)
            {
                index = i - 1;
            }
        }
        targetHorizontalPosition = PageArray[index];
        if (CreateScenePage.PageNumber == CheckTurnPageButton_CreateScene.PageOfCreateColumn1)
        {
            PageNumber1 = index + 1;
        }
        if (CreateScenePage.PageNumber == CheckTurnPageButton_CreateScene.PageOfCreateColumn2)
        {
            PageNumber2 = index + 1;
        }
    }
}
