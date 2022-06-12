using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingControls2 : MonoBehaviour
{
    public GameObject Column1_Info;
    public GameObject Info;
    public GameObject CloseInfoButton;
    public GameObject Column1;

    public void Start()
    {
        Info.SetActive(false);
        CloseInfoButton.SetActive(false);
        Column1_Info.SetActive(true);
        Column1.SetActive(true);
    }

    public void ShowInfo()
    {
        Info.SetActive(true);
        CloseInfoButton.SetActive(true);
        Column1_Info.SetActive(false);
        Column1.SetActive(false);

    }

    public void CloseInfo()
    {
        Info.SetActive(false);
        CloseInfoButton.SetActive(false);
        Column1_Info.SetActive(true);
        Column1.SetActive(true);
    }
    public void ReturnToBothColumns()
    {
           
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
           
    }
}
