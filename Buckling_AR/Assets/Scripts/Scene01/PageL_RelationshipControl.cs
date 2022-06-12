using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageL_RelationshipControl : MonoBehaviour
{
    public Text Relationship;
    public GameObject PcrxImage;
    public GameObject PcryImage;

    void Start()
    {
        Relationship.GetComponent<Text>().text = "";
        PcrxImage.SetActive(false);
        PcryImage.SetActive(false);
    }
    public void ShowPcr()
    {
        if (Relationship.GetComponent<Text>().text == "" || Relationship.GetComponent<Text>().text == ">")
        {
            Relationship.GetComponent<Text>().text = "<";
            PcrxImage.SetActive(true);
            PcryImage.SetActive(false);
        }
        else
        {
            Relationship.GetComponent<Text>().text = ">";
            PcrxImage.SetActive(false);
            PcryImage.SetActive(true);
        }

    }
}
