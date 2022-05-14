using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsForColumn2 : MonoBehaviour
{
    public void Load()
    {
        Column2.Load();
        Graph_Force.Column2Load();
        Graph_Displacement.Column2Load();

    }
    public void Renew()
    {
        Column2.Renew();
        Graph_Force.Column2Renew();
        Graph_Displacement.Column2Renew();
    }
    public void GoToEnlargeSceneForColumn2()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
