using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingControls : MonoBehaviour
{
    public GameObject Column1;
    public GameObject Column2;
    public GameObject Info;
    public GameObject CloseInfoButton;
    //public GameObject ChooseModeBoard;
    //public Toggle ExploreToggle;
    //public Toggle CreateToggle;


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

    //public void ChooseMode()
    //{
    //    ChooseModeBoard.SetActive(true);
    //}

    //public void CloseMode()
    //{
    //    ChooseModeBoard.SetActive(false);
    //}
    //public void goToMode()
    //{
    //    if (ExploreToggle.isOn == true)
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
    //    }
    //    if (CreateToggle.isOn == true)
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    //    }
    //}


}
