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
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 2)
        {
            BoundaryCondition1.transform.GetChild(BoundaryConditionPage.Parameter1).gameObject.SetActive(true);
            Section1.transform.GetChild(SectionPage.Parameter1).gameObject.SetActive(true);
            Length1.transform.GetChild(LengthPage.Parameter1).gameObject.SetActive(true);
            Bracing1.transform.GetChild(BracingPage.Parameter1).gameObject.SetActive(true);
        }
    }
}
