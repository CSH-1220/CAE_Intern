using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckTurnPageButton : MonoBehaviour
{
    public GameObject NextPageButton;
    public GameObject LastPageButton;
    public GameObject ReturnButton;
    public GameObject CreateColumnPageButton;
    public GameObject ScrollPage;

    public static int PageOfBegining = 1;
    public static int PageOfFormula = 2;
    public static int PageOfE = 3;
    public static int PageOfI = 4;
    public static int PageOfK = 5;
    public static int PageOfL = 6;
    public static int PageOfCreateColumn1 = 7;
    public static int PageOfCreateColumn2 = 8;
    public static int PageOfLast = 9;

    private void Update()
    {

        if (PreGamePage.PageNumber == PageOfBegining)
        {
            LastPageButton.SetActive(false);
            NextPageButton.SetActive(true);
            ReturnButton.SetActive(false);
            ScrollPage.GetComponent<ScrollRect>().enabled = true;
        }

        if (PreGamePage.PageNumber == PageOfFormula)
        {
            NextPageButton.SetActive(false);
            LastPageButton.SetActive(true);
            ReturnButton.SetActive(false);

            if (CheckParameterSeen.Allseen == true)
            {
                CreateColumnPageButton.SetActive(true);
            }
            else
            {
                CreateColumnPageButton.SetActive(false);
            }
        }
        if (PreGamePage.PageNumber == PageOfE || PreGamePage.PageNumber == PageOfL || PreGamePage.PageNumber == PageOfK || PreGamePage.PageNumber == PageOfI)
        {
            NextPageButton.SetActive(false);
            LastPageButton.SetActive(false);
            ReturnButton.SetActive(true);
        }
        if (PreGamePage.PageNumber == PageOfCreateColumn1)
        {
            NextPageButton.SetActive(true);
            LastPageButton.SetActive(true);
        }

        if (PreGamePage.PageNumber == PageOfLast)
        {
            NextPageButton.SetActive(false);
        }

    }

}
