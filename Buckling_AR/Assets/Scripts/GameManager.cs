using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GoToHomePageScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToPreGameScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        }
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 7);
        }
    }
    public void ReturnToPreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }

        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        }
        if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }

    }
    public void GoToNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
    public void GoToGamePlayScene()
    {
        SceneManager.LoadScene(4);
    }
}
