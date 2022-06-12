using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckTurnPageButton_CreateScene : MonoBehaviour
{
    public GameObject NextPageButton;
    public GameObject LastPageButton;
    public GameObject ScrollPage;

    public static int PageOfSelection = 1;
    public static int PageOfCreateColumn1 = 2;
    public static int PageOfCreateColumn2 = 3;
    public static int PageOfLast = 4;

    private void Update()
    {

        if (CreateScenePage.PageNumber == PageOfSelection)
        {
            LastPageButton.SetActive(false);
            NextPageButton.SetActive(false);
        }

        if (CreateScenePage.PageNumber == PageOfCreateColumn1)
        {
            NextPageButton.SetActive(true);
            LastPageButton.SetActive(true);
        }

        if (CreateScenePage.PageNumber == PageOfCreateColumn2)
        {
            NextPageButton.SetActive(true);
            LastPageButton.SetActive(true);
        }

        if (CreateScenePage.PageNumber == PageOfLast)
        {
            NextPageButton.SetActive(false);
            LastPageButton.SetActive(false);
        }

    }
}
