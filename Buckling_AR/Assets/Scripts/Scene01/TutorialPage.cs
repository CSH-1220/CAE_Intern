using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPage : MonoBehaviour
{
    private ScrollRect scrollRect;

    private static float[] PageArray = new float[] { 0f, 0.2f, 0.4f, 0.6f, 0.8f, 1f }; //6頁
    private static float targetHorizontalPosition = 0;
    public float smoothing = 5;
    private static bool go = false;

    private string[] Title = new string[] { "Buckling Tutorial", "Create Your First Column!!", "Create Your Second Column!!", "Instruction" };

    static public int PageNumber;
    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        PageNumber = 1;
    }

    void Update()
    {
        if (go == true)
        {
            scrollRect.horizontalNormalizedPosition = targetHorizontalPosition;
        }
        go = false;

        if (PageNumber <= 6)
        {
            GameObject.Find("Canvas/IntroduceBoard/Title/Text").GetComponent<Text>().text = Title[0];
            GameObject.Find("Canvas/IntroduceBoard/Title/Text").GetComponent<Text>().fontSize = 80;
        }
    }
    public void NextPage()
    {
        go = true;
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
        PageNumber = index + 1;
    }

    public void LastPage()
    {
        if (PageNumber == CheckTurnPageButton.PageOfCreateColumn1)
        {
            Invoke(nameof(GotoPageFormula), 0f);
        }
        else
        {
            go = true;
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
            PageNumber = index + 1;
        }
    }

    static public void GotoPage_E()
    {
        go = true;
        int index = 2;
        targetHorizontalPosition = PageArray[index];
        PageNumber = index + 1;
    }

    static public void GotoPage_I()
    {
        go = true;
        int index = 3;
        targetHorizontalPosition = PageArray[index];
        PageNumber = index + 1;
    }

    static public void GotoPage_K()
    {
        go = true;
        int index = 4;
        targetHorizontalPosition = PageArray[index];
        PageNumber = index + 1;
    }


    static public void GotoPage_L()
    {
        go = true;
        int index = 5;
        targetHorizontalPosition = PageArray[index];
        PageNumber = index + 1;
    }


    public void GotoPageFormula()
    {
        go = true;
        int index = 1;
        targetHorizontalPosition = PageArray[index];
        PageNumber = index + 1;
    }

    public void GotoPageCreateColumn()
    {
        go = true;
        int index = 6;
        targetHorizontalPosition = PageArray[index];
        PageNumber = index + 1;
    }
}
