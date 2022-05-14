using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingControls3 : MonoBehaviour
{
    public GameObject Column2;
    public GameObject Info;
    public GameObject CloseInfoButton;

    public void Start()
    {
        Info.SetActive(true);
        CloseInfoButton.SetActive(true);
        Column2.SetActive(false);

    }

    public void ShowInfo()
    {
        Info.SetActive(true);
        CloseInfoButton.SetActive(true);
        Column2.SetActive(false);

    }

    public void CloseInfo()
    {
        Info.SetActive(false);
        CloseInfoButton.SetActive(false);
        Column2.SetActive(true);
    }

    public void ReturnToBothColumns()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
    }

    public void ReturnToHome()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        }
    }
}
