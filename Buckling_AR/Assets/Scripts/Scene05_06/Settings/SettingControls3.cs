using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingControls3 : MonoBehaviour
{
    public GameObject Column2_Info;
    public GameObject Info;
    public GameObject CloseInfoButton;
    public GameObject Column2;

    public void Start()
    {
        Info.SetActive(false);
        CloseInfoButton.SetActive(false);
        Column2_Info.SetActive(true);
        Column2.SetActive(true);

    }

    public void ShowInfo()
    {
        Info.SetActive(true);
        CloseInfoButton.SetActive(true);
        Column2_Info.SetActive(false);
        Column2.SetActive(false);
    }

    public void CloseInfo()
    {
        Info.SetActive(false);
        CloseInfoButton.SetActive(false);
        Column2_Info.SetActive(true);
        Column2.SetActive(true);
    }

    public void ReturnToBothColumns()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
