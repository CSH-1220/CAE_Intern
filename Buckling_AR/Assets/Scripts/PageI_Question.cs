using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PageI_Question : MonoBehaviour
{
    public GameObject QuestionMark;
    public GameObject Content;
    public GameObject Question;
    public GameObject QuestionText;


    public void Start()
    {
        Content.SetActive(false);
        Question.SetActive(false);
    }

    public void ShowAnswer()
    {
                QuestionMark.SetActive(false);
                QuestionText.SetActive(false);
                Content.SetActive(true);
                Question.SetActive(true);
    }


}
