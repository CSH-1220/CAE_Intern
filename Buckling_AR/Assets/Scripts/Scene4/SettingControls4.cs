using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingControls4 : MonoBehaviour
{
    public GameObject Info;

    public void ShowInfo()
    {
        Info.SetActive(true);
    }

    public void CloseInfo()
    {
        Info.SetActive(false);
    }

}
