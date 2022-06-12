using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateScenePage : MonoBehaviour
{
    private static ScrollRect scrollRect;
    private static float[] PageArray = new float[] { 0f, 0.333f, 0.677f, 1f }; //4頁
    private static float targetHorizontalPosition = 0;
    private string[] Title = new string[] {"Create Your First Column!!", "Create Your Second Column!!", "Instruction" };
    public float smoothing = 5;
    private static bool go = false;
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

        if (PageNumber == 2)
        {
            GameObject.Find("Canvas/IntroduceBoard/Title/Text").GetComponent<Text>().text = Title[0];
            GameObject.Find("Canvas/IntroduceBoard/Title/Text").GetComponent<Text>().fontSize = 48;
        }
        if (PageNumber == 3)
        {
            GameObject.Find("Canvas/IntroduceBoard/Title/Text").GetComponent<Text>().text = Title[1];
            GameObject.Find("Canvas/IntroduceBoard/Title/Text").GetComponent<Text>().fontSize = 48;
        }
        if (PageNumber == 4)
        {
            GameObject.Find("Canvas/IntroduceBoard/Title/Text").GetComponent<Text>().text = Title[2];
            GameObject.Find("Canvas/IntroduceBoard/Title/Text").GetComponent<Text>().fontSize = 80;
        }
    }
    public static void NextPage()
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
