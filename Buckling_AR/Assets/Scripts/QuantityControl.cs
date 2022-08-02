using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantityControl : MonoBehaviour
{

    public GameObject QuantityBoard;
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    public GameObject Page4;
    public static int ColumnNum;
    int MaxColumnNum = 4;

    void Start()
    {
        ColumnNum = 1;
        Page1.SetActive(true);
        Page2.SetActive(false);
        Page3.SetActive(false);
        Page4.SetActive(false);
        QuantityBoard.SetActive(false);
    }

    public void OKButton()
    {
        CreateScenePage.NextPage();
    }

    public void CancelButton()
    {
        QuantityBoard.SetActive(false);
    }

    public void DecreaseColumn()
    {
        if (ColumnNum == 1)
        {
            Page1.SetActive(true);
            Page2.SetActive(false);
            Page3.SetActive(false);
            Page4.SetActive(false);

        }
        else if (ColumnNum == 2)
        {
            Page1.SetActive(true);
            Page2.SetActive(false);
            Page3.SetActive(false);
            Page4.SetActive(false);
            ColumnNum -= 1;
        }
        else if (ColumnNum == 3)
        {
            Page1.SetActive(false);
            Page2.SetActive(true);
            Page3.SetActive(false);
            Page4.SetActive(false);
            ColumnNum -= 1;
        }
        else if (ColumnNum == 4)
        {
            Page1.SetActive(false);
            Page2.SetActive(false);
            Page3.SetActive(true);
            Page4.SetActive(false);
            ColumnNum -= 1;
        }
    }
    public void IncreaseColumn()
    {

        Debug.Log(ColumnNum);
        if (ColumnNum == 1)
        {
            Page1.SetActive(false);
            Page2.SetActive(true);
            Page3.SetActive(false);
            Page4.SetActive(false);
            if (ColumnNum < MaxColumnNum)
            {
                ColumnNum = 2;
            }
        }
        else if (ColumnNum == 2)
        {
            Page1.SetActive(false);
            Page2.SetActive(false);
            Page3.SetActive(true);
            Page4.SetActive(false);
            if (ColumnNum < MaxColumnNum)
            {
                ColumnNum = 3;
            }
        }
        else if (ColumnNum == 3)
        {
            Page1.SetActive(false);
            Page2.SetActive(false);
            Page3.SetActive(false);
            Page4.SetActive(true);
            if (ColumnNum < MaxColumnNum)
            {
                ColumnNum = 4;
            }
        }
    }
}
