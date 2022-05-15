using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingControls4 : MonoBehaviour
{
    public GameObject Info;
    public GameObject SubmitButton;

    public void ShowInfo()
    {
        Info.SetActive(true);
        SubmitButton.SetActive(false);
    }
    public void CloseInfo()
    {
        Info.SetActive(false);
        SubmitButton.SetActive(true);
    }

}
