using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckParameterSeen_Tutorial : MonoBehaviour
{
    public GameObject Seen_E;
    public GameObject Seen_I;
    public GameObject Seen_K;
    public GameObject Seen_L;

    private bool SeenPageE = false;
    private bool SeenPageI = false;
    private bool SeenPageK = false;
    private bool SeenPageL = false;

    public static bool Allseen = false;


    void Update()
    {
        if (TutorialPage.PageNumber == CheckTurnPageButton_Tutorial.PageOfE)
        {
            SeenPageE = true;
            Seen_E.SetActive(true);
        }
        if (TutorialPage.PageNumber == CheckTurnPageButton_Tutorial.PageOfI)
        {
            SeenPageI = true;
            Seen_I.SetActive(true);
        }
        if (TutorialPage.PageNumber == CheckTurnPageButton_Tutorial.PageOfK)
        {
            SeenPageK = true;
            Seen_K.SetActive(true);
        }
        if (TutorialPage.PageNumber == CheckTurnPageButton_Tutorial.PageOfL)
        {
            SeenPageL = true;
            Seen_L.SetActive(true);
        }
        if (SeenPageE == false)
        {
            Seen_E.SetActive(false);
        }
        if (SeenPageI == false)
        {
            Seen_I.SetActive(false);
        }
        if (SeenPageK == false)
        {
            Seen_K.SetActive(false);
        }
        if (SeenPageL == false)
        {
            Seen_L.SetActive(false);
        }
        if (SeenPageE == true && SeenPageI == true && SeenPageK == true && SeenPageL == true)
        {
            Allseen = true;
        }
    }
}
