using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GoToPreGameScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

    }

    public void GoToGamePlayScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (PreGamePage.PageNumber == CheckTurnPageButton.PageOfLast)
            {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
