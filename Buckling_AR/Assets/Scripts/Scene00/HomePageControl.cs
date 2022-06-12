using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomePageControl : MonoBehaviour
{
    public GameObject Page1;
    public GameObject Page2;
    private bool startGame=true;


    public Toggle ExploreToggle;
    public Toggle CreateToggle;
    public Toggle ReviewToggle;


    public void Start()
    {
        if (startGame==true)
        {
            Page1.SetActive(true);
            Page2.SetActive(false);
        }

        if (startGame == false)
        {
            Page1.SetActive(false);
            Page2.SetActive(true);
        }
    }

    public void gamePlay()
    {
        Page1.SetActive(false);
        Page2.SetActive(true);
        startGame = false;
    }

    public void goToMode()
    {
        //Review buckling formula
        if (ReviewToggle.isOn == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        //Go to explore mode
        if (ExploreToggle.isOn == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        //Go to create mode
        if (CreateToggle.isOn == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }


    }

}
