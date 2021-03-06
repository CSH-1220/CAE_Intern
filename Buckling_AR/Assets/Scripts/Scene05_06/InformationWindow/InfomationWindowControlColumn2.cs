using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfomationWindowControlColumn2 : MonoBehaviour
{
    public GameObject BoundaryCondition2;
    public GameObject Section2;
    public GameObject Length2;
    public GameObject Bracing2;
    private void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 6)
        {
            BoundaryCondition2.transform.GetChild(BCPage.Parameter2).gameObject.SetActive(true);
            Section2.transform.GetChild(SPage.Parameter2).gameObject.SetActive(true);
            Length2.transform.GetChild(LPage.Parameter2).gameObject.SetActive(true);
            Bracing2.transform.GetChild(BPage.Parameter2).gameObject.SetActive(true);
        }
    }
}
