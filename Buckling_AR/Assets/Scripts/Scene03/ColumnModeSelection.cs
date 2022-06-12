using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColumnModeSelection : MonoBehaviour
{
    public Toggle DataBaseToggle;
    public Toggle SurroundingsToggle;

    public void goToMode()
    {
        //Review buckling formula
        if (DataBaseToggle.isOn == true)
        {
            CreateScenePage.NextPage();
        }
        //Go to explore mode
        if (SurroundingsToggle.isOn == true)
        {
            SceneManager.LoadScene(7);
        }
    }
}
