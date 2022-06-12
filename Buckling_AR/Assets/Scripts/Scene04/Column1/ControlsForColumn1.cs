using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsForColumn1 : MonoBehaviour
{
    public void Load()
    {
        Column1.Load();
        Graph_Force.Column1Load();
        Graph_Displacement.Column1Load();
    }
    public void Renew()
    {
        Column1.Renew();
        Graph_Force.Column1Renew();
        Graph_Displacement.Column1Renew();
    }
    public void GoToEnlargeSceneForColumn1()
    {
            SceneManager.LoadScene(5);
    }
}
