using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingControls2 : MonoBehaviour
{
    public GameObject Column1;
    public GameObject Info;
    public GameObject CloseInfoButton;

    public void Start()
    {
        Info.SetActive(true);
        CloseInfoButton.SetActive(true);
        Column1.SetActive(false);

    }

    public void ShowInfo()
    {
        Info.SetActive(true);
        CloseInfoButton.SetActive(true);
        Column1.SetActive(false);

    }

    public void CloseInfo()
    {
        Info.SetActive(false);
        CloseInfoButton.SetActive(false);
        Column1.SetActive(true);
    }

    public void ReturnToBothColumns()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
           
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
           
        }
    }

    public void ReturnToHome()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
    }
}
