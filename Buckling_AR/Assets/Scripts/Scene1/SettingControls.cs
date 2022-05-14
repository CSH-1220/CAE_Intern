using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingControls : MonoBehaviour
{
    public GameObject Column1;
    public GameObject Column2;
    public GameObject Info;
    public GameObject CloseInfoButton;

    public void Start()
    {
        Info.SetActive(true);
        CloseInfoButton.SetActive(true);
        Column1.SetActive(false);
        Column2.SetActive(false);
    }

    public void ShowInfo()
    {
        Info.SetActive(true);
        CloseInfoButton.SetActive(true);
        Column1.SetActive(false);
        Column2.SetActive(false);
    }

    public void CloseInfo()
    {
        Info.SetActive(false);
        CloseInfoButton.SetActive(false);
        Column1.SetActive(true);
        Column2.SetActive(true);
    }
}
