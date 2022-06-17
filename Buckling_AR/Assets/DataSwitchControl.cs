using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSwitchControl : MonoBehaviour
{
    public GameObject ForceBoard;
    public GameObject DisplacementBoard;


    public static int DataNum;
    public static int MaxDataNum = 2;

    void Start()
    {
        DataNum = 1;
        ForceBoard.SetActive(true);
        DisplacementBoard.SetActive(false);
    }

    public void LastData()
    {
        if (DataNum == 1)
        {
            ForceBoard.SetActive(true);
            DisplacementBoard.SetActive(false);
        }
        if (DataNum == 2)
        {
            ForceBoard.SetActive(true);
            DisplacementBoard.SetActive(false);
            DataNum -= 1;
        }
    }
    public void NextData()
    {
        if (DataNum == 1 && DataNum < MaxDataNum)
        {
            ForceBoard.SetActive(false);
            DisplacementBoard.SetActive(true);
            if (DataNum < MaxDataNum)
            {
                DataNum += 1;
            }

        }
        if (DataNum == 2 && DataNum < MaxDataNum)
        {
            ForceBoard.SetActive(false);
            DisplacementBoard.SetActive(false);
            if (DataNum < MaxDataNum)
            {
                DataNum += 1;
            }
        }
    }
}