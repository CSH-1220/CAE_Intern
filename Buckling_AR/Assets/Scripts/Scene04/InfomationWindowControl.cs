using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfomationWindowControl : MonoBehaviour
{
    public GameObject BoundaryCondition1;
    public GameObject Section1;
    public GameObject Length1;
    public GameObject Bracing1;

    public GameObject BoundaryCondition2;
    public GameObject Section2;
    public GameObject Length2;
    public GameObject Bracing2;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            BoundaryCondition1.transform.GetChild(BCPage.Parameter1).gameObject.SetActive(true);
            Section1.transform.GetChild(SPage.Parameter1).gameObject.SetActive(true);
            Length1.transform.GetChild(LPage.Parameter1).gameObject.SetActive(true);
            Bracing1.transform.GetChild(BPage.Parameter1).gameObject.SetActive(true);

            BoundaryCondition2.transform.GetChild(BCPage.Parameter2).gameObject.SetActive(true);
            Section2.transform.GetChild(SPage.Parameter2).gameObject.SetActive(true);
            Length2.transform.GetChild(LPage.Parameter2).gameObject.SetActive(true);
            Bracing2.transform.GetChild(BPage.Parameter2).gameObject.SetActive(true);
        }
    }
}
