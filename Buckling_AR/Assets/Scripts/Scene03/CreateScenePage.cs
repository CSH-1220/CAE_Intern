using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateScenePage : MonoBehaviour
{
    private static ScrollRect scrollRect;
    private static float[] PageArray = new float[] { 0f, 0.2f, 0.4f, 0.6f, 0.8f, 1f }; //6頁
    private static float targetHorizontalPosition = 0;
    private string[] Title = new string[] {"Create Your First Column!!", "Create Your Second Column!!", "Create Your Third Column!!", "Create Your Fourth Column!!", "Instruction" };
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
            GameObject.Find("Canvas/IntroduceBoard/Title/Text").GetComponent<Text>().fontSize = 48;
        }
        if (PageNumber == 5)
        {
            GameObject.Find("Canvas/IntroduceBoard/Title/Text").GetComponent<Text>().text = Title[3];
            GameObject.Find("Canvas/IntroduceBoard/Title/Text").GetComponent<Text>().fontSize = 48;
        }

        if (PageNumber == 6)
        {
            GameObject.Find("Canvas/IntroduceBoard/Title/Text").GetComponent<Text>().text = Title[4];
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
        if (QuantityControl.ColumnNum == 1 && PageNumber == 2)
        {
            targetHorizontalPosition = PageArray[5];
            PageNumber = 6;
        }
        else if (QuantityControl.ColumnNum==2 && PageNumber==3)
        {
            targetHorizontalPosition = PageArray[5];
            PageNumber = 6;
        }
        else if (QuantityControl.ColumnNum == 3 && PageNumber == 4)
        {
            targetHorizontalPosition = PageArray[5];
            PageNumber = 6;
        }
        else if (QuantityControl.ColumnNum == 4 && PageNumber == 5)
        {
            targetHorizontalPosition = PageArray[5];
            PageNumber = 6;
        }
        else
        {
            targetHorizontalPosition = PageArray[index];
            PageNumber = index + 1;
        }

    }

    public void LastPage()
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
        if (QuantityControl.ColumnNum == 1 && PageNumber == 6)
        {
            targetHorizontalPosition = PageArray[1];
            PageNumber = 2;
        }
        else if (QuantityControl.ColumnNum == 2 && PageNumber == 6)
        {
            targetHorizontalPosition = PageArray[2];
            PageNumber = 3;
        }
        else if (QuantityControl.ColumnNum == 3 && PageNumber == 6)
        {
            targetHorizontalPosition = PageArray[3];
            PageNumber = 4;
        }
        else if (QuantityControl.ColumnNum == 4 && PageNumber == 6)
        {
            targetHorizontalPosition = PageArray[4];
            PageNumber = 5;
        }
        else
        {
            targetHorizontalPosition = PageArray[index];
            PageNumber = index + 1;
        }
    }
}
