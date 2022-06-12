using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfomationWindowControlColumn1 : MonoBehaviour
{
    public GameObject BoundaryCondition1;
    public GameObject Section1;
    public GameObject Length1;
    public GameObject Bracing1;
    private void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 5)
        {
            BoundaryCondition1.transform.GetChild(BCPage.Parameter1).gameObject.SetActive(true);
            Section1.transform.GetChild(SPage.Parameter1).gameObject.SetActive(true);
            Length1.transform.GetChild(LPage.Parameter1).gameObject.SetActive(true);
            Bracing1.transform.GetChild(BPage.Parameter1).gameObject.SetActive(true);
        }
    }
}
