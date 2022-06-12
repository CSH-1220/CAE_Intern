using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckTurnPageButton_Tutorial : MonoBehaviour
{
    public GameObject NextPageButton;
    public GameObject LastPageButton;
    public GameObject ReturnButton;
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

        if (TutorialPage.PageNumber == PageOfBegining)
        {
            LastPageButton.SetActive(false);
            NextPageButton.SetActive(true);
            ReturnButton.SetActive(false);
            ScrollPage.GetComponent<ScrollRect>().enabled = true;
        }

        if (TutorialPage.PageNumber == PageOfFormula)
        {
            NextPageButton.SetActive(false);
            LastPageButton.SetActive(true);
            ReturnButton.SetActive(false);
        }
        if (TutorialPage.PageNumber == PageOfE || TutorialPage.PageNumber == PageOfL || TutorialPage.PageNumber == PageOfK || TutorialPage.PageNumber == PageOfI)
        {
            NextPageButton.SetActive(false);
            LastPageButton.SetActive(false);
            ReturnButton.SetActive(true);
        }
        if (TutorialPage.PageNumber == PageOfCreateColumn1)
        {
            NextPageButton.SetActive(true);
            LastPageButton.SetActive(true);
        }

        if (TutorialPage.PageNumber == PageOfLast)
        {
            NextPageButton.SetActive(false);
        }

    }
}
