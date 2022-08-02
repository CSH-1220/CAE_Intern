using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnInfoSwitchControl : MonoBehaviour
{
    public GameObject Column1;
    public GameObject Column2;
    //public GameObject Column3;
    //public GameObject Column4;

    public static int ColumnNum;
    public static int MaxColumnNum = 2;

    void Start()
    {
        ColumnNum = 1;
        Column1.SetActive(true);
        Column2.SetActive(false);
        //Column3.SetActive(false);
        //Column4.SetActive(false);
    }
    public void LastColumn()
    {
        if (ColumnNum == 1)
        {
            Column1.SetActive(true);
            Column2.SetActive(false);
            //Column3.SetActive(false);
            //Column4.SetActive(false);

        }
        if (ColumnNum == 2)
        {
            Column1.SetActive(true);
            Column2.SetActive(false);
            //Column3.SetActive(false);
            //Column4.SetActive(false);
            ColumnNum -=1;
        }
    }
    public void NextColumn()
    {
        if (ColumnNum == 1 && ColumnNum < MaxColumnNum)
        {
            Column1.SetActive(false);
            Column2.SetActive(true);
            //Column3.SetActive(false);
            //Column4.SetActive(false);
            if (ColumnNum < MaxColumnNum)
            {
                ColumnNum +=1;
            }

        }
        if (ColumnNum == 2 && ColumnNum < MaxColumnNum)
        {
            Column1.SetActive(false);
            Column2.SetActive(false);
            //Column3.SetActive(true);
            //Column4.SetActive(false);
            if (ColumnNum < MaxColumnNum)
            {
                ColumnNum +=1;
            }
        }
    }
}