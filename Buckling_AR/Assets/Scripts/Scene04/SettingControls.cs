using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingControls : MonoBehaviour
{
    public GameObject Columns;
    public GameObject Info;
    public GameObject Switch;
    public GameObject CloseInfoButton;

    public void Start()
    {
        Info.SetActive(true);
        CloseInfoButton.SetActive(true);
        Switch.SetActive(false);
        Columns.SetActive(false);
    }

    public void ShowInfo()
    {
        Info.SetActive(true);
        CloseInfoButton.SetActive(true);
        Switch.SetActive(false);
        Columns.SetActive(false);
    }

    public void CloseInfo()
    {
        Info.SetActive(false);
        CloseInfoButton.SetActive(false);
        Switch.SetActive(true);
        Columns.SetActive(true);
    }
}
